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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();

            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _clientService.GetById(id);
            if (result == null) return NotFound();

            var response = _mapper.Map<ClientResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateClient([FromBody] ClientRequest clientRequest)
        {
            if(clientRequest == null) return BadRequest();

            var client = _mapper.Map<Client>(clientRequest);
            var result = _clientService.Create(client);

            return Ok(client);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var result = _clientService.Delete(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ClientUpdateRequest clientRequest)
        {
            if (clientRequest == null) return BadRequest();

            var searchClient = _clientService.GetById(clientRequest.Id);
            if(searchClient == null) return NotFound(clientRequest.Id);

            searchClient.Name = clientRequest.Name;
            searchClient.PaymentType = clientRequest.PaymentType;
            searchClient.Discount = clientRequest.Discount;
            searchClient.Car = clientRequest.Car;

            var result = _clientService.Update(searchClient);

            return Ok(result);
        }



    }
}
