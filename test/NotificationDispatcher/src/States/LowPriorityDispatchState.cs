using System;
using NotificationDispatcher.src.States.Helpers;
using NotificationDispatcher.src.States.Interfaces;

namespace NotificationDispatcher.src.States;

internal class LowPriorityDispatchState : IDispatchState
{
    private DateTime? _lastLowPriorityDispatch;

    public DateTime GetScheduledTime(DateTime notificationCreated) => ScheduledTimeHelper.GetScheduledTime(notificationCreated, ref _lastLowPriorityDispatch, TimeSpan.FromHours(24));
}