using AutoMapper;
using CarShop.BL.Interfaces;
using CarShop.BL.Services;
using CarShop.Controllers;
using CarShop.DL.Interfaces;
using CarShop.Extensions;
using CarShop.Models.DTO;
using CarShop.Models.Requests;
using CarShop.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace CarShop.Test
{
    public class CarTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICarRepository> _carRepository;
        private readonly ICarService _carService;
        private readonly CarController _carController;

        private IList<Car> Cars = new List<Car>()
        {
            new Car()
            {
                Id = 1,
                Make = "TestMake1",
                Model = "TestModel1"
            },

            new Car()
            {
                Id=2,
                Make = "TestMake2",
                Model = "TestModel2"
            }
        };

        public CarTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _carRepository = new Mock<ICarRepository>();

            var logger = new Mock<ILogger>();

            _carService = new CarService(_carRepository.Object, logger.Object);

            _carController = new CarController(_carService, _mapper);
        }

        [Fact]
        public void Car_GetAll_Count_Check()
        {
            var expectedCount = 2;

            var mockedService = new Mock<ICarService>();
            mockedService.Setup(x => x.GetAll()).Returns(Cars);

            var controller = new CarController(mockedService.Object, _mapper);

            var result = controller.GetAll();

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var cars = okObjectResult.Value as IEnumerable<Car>;
            Assert.NotNull(cars);
            Assert.Equal(expectedCount, cars.Count());
        }

        [Fact]
        public void Car_GetById_ModelCheck()
        {

            var carId = 2;
            var expectedModel = "TestModel2";

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));

            var result = _carController.GetById(carId);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as CarResponse;
            var car = _mapper.Map<Car>(response);

            Assert.NotNull(car);
            Assert.Equal(expectedModel, car.Model);
        }

        [Fact]
        public void Car_GetById_MakeCheck()
        {

            var carId = 2;
            var expectedMake = "TestMake2";

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));

            var result = _carController.GetById(carId);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as CarResponse;
            var car = _mapper.Map<Car>(response);

            Assert.NotNull(car);
            Assert.Equal(expectedMake, car.Make);
        }

        [Fact]
        public void Car_GetById_NotFound()
        {

            var carId = 3;

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));

            var result = _carController.GetById(carId);

            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(carId, response);
        }

        [Fact]
        public void Car_Update_CarMakeAndModel()
        {
            var carId = 1;
            var expectedMake = "Updated Car Make";
            var expectedModel = "Updated Car Model";

            var car = Cars.FirstOrDefault(x => x.Id == carId);
            car.Make = expectedMake;
            car.Model = expectedModel;

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));
            _carRepository.Setup(x => x.Update(car))
                .Returns(car);

            var carUpdateRequest = _mapper.Map<CarUpdateRequest>(car);
            var result = _carController.Update(carUpdateRequest);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Car;
            Assert.NotNull(val);
            Assert.Equal(expectedMake, val.Make);
            Assert.Equal(expectedModel, val.Model);

        }

        [Fact]
        public void Car_Delete_ExistingCar()
        {
            var carId = 1;

            var car = Cars.FirstOrDefault(x => x.Id == carId);

            _carRepository.Setup(x => x.Delete(carId)).Callback(() => Cars.Remove(car)).Returns(car);

            var result = _carController.Delete(carId);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Car;
            Assert.NotNull(val);
            Assert.Equal(1, Cars.Count);
            Assert.Null(Cars.FirstOrDefault(x => x.Id == carId));
        }

        [Fact]
        public void Car_Delete_NotExisting_Car()
        {
            var carId = 3;

            var car = Cars.FirstOrDefault(x => x.Id == carId);

            _carRepository.Setup(x => x.Delete(carId)).Callback(() => Cars.Remove(car)).Returns(car);

            var result = _carController.Delete(carId);

            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(carId, response);
        }

        [Fact]
        public void Car_CreateCar()
        {
            var car = new Car()
            {
                Id = 3,
                Make = "TestMake3",
                Model = "TestModel3"
            };

            _carRepository.Setup(x => x.GetAll()).Returns(Cars);

            _carRepository.Setup(x => x.Create(It.IsAny<Car>())).Callback(() =>
            {
                Cars.Add(car);
            }).Returns(car);

            var result = _carController.CreateCar(_mapper.Map<CarRequest>(car));

            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Cars.FirstOrDefault(x => x.Id == car.Id));
            Assert.Equal(3, Cars.Count);

        }
    }
}
