using System;
using NotificationDispatcher.src.States.Helpers;
using NotificationDispatcher.src.States.Interfaces;

namespace NotificationDispatcher.src.States;

internal class HighPriorityDispatchState : IDispatchState
{
    private DateTime? _lastHighPriorityDispatch;

    public DateTime GetScheduledTime(DateTime notificationCreated) => ScheduledTimeHelper.GetScheduledTime(notificationCreated, ref _lastHighPriorityDispatch, TimeSpan.FromMinutes(1));
}