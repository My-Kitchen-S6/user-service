using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using user_service.AsyncDataServices;
using user_service.Data;
using user_service.DTOs;
using user_service.Models;

namespace user_service.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public UsersController(
            IUserRepo repository,
            IMapper mapper,
            IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet("[controller]/all", Name = "GetAllUsers")]
        public ActionResult<IEnumerable<ReadUser>> GetUsers()
        {
            Console.WriteLine("--> Getting Users.... ");
            var userItem = _repository.getAllUsers();
            return Ok(_mapper.Map<IEnumerable<ReadUser>>(userItem));
        }
        
        [HttpGet("[controller]/{id}", Name = "GetUserById")]
        public ActionResult<ReadUser> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if(userItem != null)
            {
                return Ok(_mapper.Map<ReadUser>(userItem));
            }

            return NotFound();
        }
        
        [HttpGet("[controller]/auth0/{auth0id}",Name = "GetUserByAuth0Id")]
        public ActionResult<ReadUser> GetUserByAuth0Id(string auth0Id)
        {
            
            Console.WriteLine("--> Checking auth0Id");
            var userItem = _repository.GetUserByAuth0Id(auth0Id);
            if (userItem != null)
            {
                return Ok(_mapper.Map<ReadUser>(userItem));
            }
            
            return NotFound();
            
        }
        
        [HttpPost("[controller]/create", Name = "CreateUser")]
        public async Task<ActionResult<ReadUser>> CreateUser(CreateUser createUser)
        {
            var userModel = _mapper.Map<User>(createUser);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<ReadUser>(userModel);
            
            // try
            // {
            //     var publishedUserDto = _mapper.Map<PublishedUser>(userReadDto);
            //     publishedUserDto.Event = "User_Published";
            //     _messageBusClient.PublishNewUser(publishedUserDto);
            // }
            // catch(Exception e)
            // {
            //     Console.WriteLine($"--> Could not send Asynchronously: {e.Message}");
            // }

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);
        }
    }
}