﻿using AutoMapper;
using CarShop.BL.Interfaces;
using CarShop.Models.DTO;
using CarShop.Models.Requests;
using CarShop.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _serviceService.GetAll();

            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _serviceService.GetById(id);
            if (result == null) return NotFound();

            var response = _mapper.Map<ServiceResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateService([FromBody] ServiceRequest serviceRequest)
        {
            if (serviceRequest == null) return BadRequest();

            var service = _mapper.Map<Service>(serviceRequest);
            var result = _serviceService.Create(service);

            return Ok(service);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var result = _serviceService.Delete(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ServiceUpdateRequest serviceRequest)
        {
            if (serviceRequest == null) return BadRequest();

            var searchService = _serviceService.GetById(serviceRequest.Id);
            if (searchService == null) return NotFound(serviceRequest.Id);

            searchService.Name = serviceRequest.Name;
            searchService.Price = serviceRequest.Price;

            var result = _serviceService.Update(searchService);

            return Ok(result);
        }



    }
}
