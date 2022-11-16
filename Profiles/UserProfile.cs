using user_service.DTOs;
using user_service.Models;
using AutoMapper;

namespace user_service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //source -> target
            CreateMap<User, ReadUser>();
            CreateMap<CreateUser, User>();
            CreateMap<ReadUser, PublishedUser>();
        }
        
    }
}