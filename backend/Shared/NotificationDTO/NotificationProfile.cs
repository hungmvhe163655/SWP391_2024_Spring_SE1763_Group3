using AutoMapper;
using Entities.Models;

namespace Shared.NotificationDTO
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, ReadNotificationDTO>();
        }
    }
}
