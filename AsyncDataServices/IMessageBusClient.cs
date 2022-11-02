using user_service.DTOs;

namespace user_service.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewUser( PublishedUser publishedUser);
    }
}