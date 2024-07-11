using System;

namespace NotificationDispatcher.src.States.Interfaces
{
    public interface IDispatchState
    {
        DateTime GetScheduledTime(DateTime notificationCreated);
    }
}