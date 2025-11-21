using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface INotificationService
    {

            Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto dto); 
            Task<List<NotificationDto>> GetUserNotificationsAsync(string userId);
            Task MarkAsReadAsync(Guid id);
            Task DeleteNotificationAsync(Guid id);
        }

    }

