using System;
using NotificationDispatcher.src.States.Interfaces;

namespace NotificationDispatcher.src.States;

internal class DispatchState
{
    private readonly IDispatchState _highPriorityState;
    private readonly IDispatchState _lowPriorityState;
    private IDispatchState _currentState;

    public DispatchState()
    {
        _highPriorityState = new HighPriorityDispatchState();
        _lowPriorityState = new LowPriorityDispatchState();

        _currentState = _highPriorityState;
    }
    public DateTime GetPriorityScheduledTime(DateTime notificationCreated, NotificationPriority state)
    {
        return state switch
        {
            NotificationPriority.Low => _currentState.GetScheduledTime(notificationCreated),
            NotificationPriority.High => _currentState.GetScheduledTime(notificationCreated),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null),
        };
    }

    #region Optional switch priority methods
    public void SetStateToHighPriority()
    {
        _currentState = _highPriorityState;
    }

    public void SetStateToLowPriority()
    {
        _currentState = _lowPriorityState;
    }
    #endregion
}