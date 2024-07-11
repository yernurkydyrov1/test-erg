using System;

namespace NotificationDispatcher.src.States.Helpers;

public static class ScheduledTimeHelper
{
    public static DateTime GetScheduledTime(DateTime notificationCreated, ref DateTime? lastDispatch, TimeSpan interval)
    {
        if (!lastDispatch.HasValue || lastDispatch <= notificationCreated)
        {
            lastDispatch = notificationCreated.Add(interval);
            return notificationCreated;
        }

        lastDispatch = lastDispatch.Value.Add(interval);
        return lastDispatch.Value;
    }
}