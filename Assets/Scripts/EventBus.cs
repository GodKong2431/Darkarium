using System;
using System.Collections.Generic;

public static class EventBus
{
    //이벤트 모음
    private static Dictionary<EventType, Delegate> _eventTable = new Dictionary<EventType, Delegate>();


    //이벤트 추가 메서드들
    public static void AddListener(EventType evt, Action listener)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            _eventTable[evt] = (Action)del + listener;
        else
            _eventTable[evt] = listener;
    }
    public static void AddListener<T>(EventType evt, Action<T> listener)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            _eventTable[evt] = (Action<T>)del + listener;
        else
            _eventTable[evt] = listener;
    }
    public static void AddListener<T1, T2>(EventType evt, Action<T1, T2> listener)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            _eventTable[evt] = (Action<T1, T2>)del + listener;
        else
            _eventTable[evt] = listener;
    }

    //이벤트 제거 메서드들
    public static void RemoveListener(EventType evt, Action listener)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            _eventTable[evt] = (Action)del - listener;
    }
    public static void RemoveListener<T>(EventType evt, Action<T> listener)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            _eventTable[evt] = (Action<T>)del - listener;
    }
    public static void RemoveListener<T1, T2>(EventType evt, Action<T1, T2> listener)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            _eventTable[evt] = (Action<T1, T2>)del - listener;
    }

    //이벤트 실행 메서드들
    public static void Trigger(EventType evt)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            (del as Action)?.DynamicInvoke();
    }
    public static void Trigger<T>(EventType evt, T param)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            (del as Action<T>)?.DynamicInvoke(param);
    }
    public static void Trigger<T1, T2>(EventType evt, T1 p1, T2 p2)
    {
        if (_eventTable.TryGetValue(evt, out var del))
            (del as Action<T1, T2>)?.DynamicInvoke(p1, p2);
    }
}
