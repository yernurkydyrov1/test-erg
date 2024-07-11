using System;

namespace NotificationDispatcher.src;
internal record ScheduledNotification
{
    public DateTime ScheduledDeliveryTime { get; set; }
    public required Notification Notification { get; set; }
}
