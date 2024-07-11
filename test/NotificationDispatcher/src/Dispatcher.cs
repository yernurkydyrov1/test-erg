using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NotificationDispatcher.src.States;

namespace NotificationDispatcher.src;

internal class Dispatcher
{
    private readonly List<Notification> _notifications = [];
    private readonly Dictionary<string, DispatchState> _dispatchStates = [];

    /// <summary>
    /// Добавляет сообщение в систему
    /// </summary>
    public void PushNotification(Notification notification)
    {
        // TODO: Implement
        _notifications.Add(notification);
        Console.WriteLine($"Pushed: {notification.MessengerAccount} - {notification.Message}");
    }

    /// <summary>
    /// Вовзращает порядок отправки сообщений
    /// </summary>
    public ReadOnlyCollection<ScheduledNotification> GetOrderedNotifications()
    {
        // TODO: Implement
        var scheduledNotifications = _notifications
           .OrderBy(n => n.Created)
           .Select(CreateScheduledNotification)
           .OrderBy(sn => sn.ScheduledDeliveryTime)
           .ToList()
           .AsReadOnly();

        return scheduledNotifications;
    }

    #region Helpers
    private ScheduledNotification CreateScheduledNotification(Notification notification)
    {
        var scheduledTime = GetScheduledTime(notification);

        return new ScheduledNotification
        {
            ScheduledDeliveryTime = scheduledTime,
            Notification = notification
        };
    }

    private DateTime GetScheduledTime(Notification notification)
    {
        var dispatchState = GetOrCreateDispatchState(notification.MessengerAccount);
        var priority = notification.Priority == NotificationPriority.High ? NotificationPriority.High : NotificationPriority.Low;

        return dispatchState.GetPriorityScheduledTime(notification.Created, priority);
    }

    private DispatchState GetOrCreateDispatchState(string messengerAccount)
    {
        if (!_dispatchStates.TryGetValue(messengerAccount, out var state))
        {
            state = new DispatchState();
            _dispatchStates[messengerAccount] = state;
        }
        return state;
    }
    #endregion
}