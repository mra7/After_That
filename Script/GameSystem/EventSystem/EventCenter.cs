using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    private static Dictionary<EventType, Delegate> eventDic = new Dictionary<EventType, Delegate>();
    #region 通用部分 + 抛异常
    private static void OnListenerAdding(EventType eventType, Delegate callBack)
    {
        if (!eventDic.ContainsKey(eventType))
        {
            eventDic.Add(eventType, null);
        }
        Delegate d = eventDic[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托是{1}，要添加的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
        }
    }
    private static void OnListenerRemoving(EventType eventType, Delegate callBack)
    {
        if (eventDic.ContainsKey(eventType))
        {
            Delegate d = eventDic[eventType];
            if (d == null)
            {
                throw new Exception(String.Format("该事件码下没有事件", eventType));
            }
            if (d != null && d.GetType() != callBack.GetType())
            {
                throw new Exception(String.Format("尝试为事件{0}移除不同类型的委托，当前事件所对应的委托是{1}，要添加的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(String.Format("没有事件码{0}", eventType));
        }
    }
    #endregion
    #region 无参数事件
    public static void AddListener(EventType eventType, CallBack callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack)eventDic[eventType] + callBack;
    }
    public static void RemoveListener(EventType eventType, CallBack callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack)eventDic[eventType] - callBack;
    }
    public static void Boardcast(EventType eventType)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        { 
            CallBack callback = d as CallBack;
            if (callback == null)
            {
                throw new Exception(String.Format("广播事件错误，事件{0}具有不同的委托类型", eventType));
            }
            else
            {
                callback();   
            }
        }
    }
    #endregion
    #region 一个参数
    public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T>(EventType eventType, T arg)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T> callback = d as CallBack<T>;
            if (callback == null)
            {
                throw new Exception(String.Format("广播事件错误，事件{0}具有不同的委托类型", eventType));
            }
            else
            {
                callback(arg);
            }
        }
    }
    #endregion
    #region 两个参数
    public static void AddListener<T, X>(EventType eventType, CallBack<T, X> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X>(EventType eventType, CallBack<T, X> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X>(EventType eventType, T arg, X arg2)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X> callback = d as CallBack<T, X>;
            if (callback == null)
            {
                throw new Exception(String.Format("广播事件错误，事件{0}具有不同的委托类型", eventType));
            }
            else
            {
                callback(arg, arg2);
            }
        }
    }
    #endregion
    #region 三个参数
    public static void AddListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X, Y>(EventType eventType, T arg, X arg2, Y arg3)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y> callback = d as CallBack<T, X, Y>;
            if (callback == null)
            {
                throw new Exception(String.Format("广播事件错误，事件{0}具有不同的委托类型", eventType));
            }
            else
            {
                callback(arg, arg2, arg3);
            }
        }
    }
    #endregion
    #region 四个参数
    public static void AddListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X, Y, Z>(EventType eventType, T arg, X arg2, Y arg3, Z arg4)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z> callback = d as CallBack<T, X, Y, Z>;
            if (callback == null)
            {
                throw new Exception(String.Format("广播事件错误，事件{0}具有不同的委托类型", eventType));
            }
            else
            {
                callback(arg, arg2, arg3, arg4);
            }
        }
    }
    #endregion
    #region 五个参数
    public static void AddListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z, W>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z, W>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X, Y, Z, W>(EventType eventType, T arg, X arg2, Y arg3, Z arg4, W arg5)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z, W> callback = d as CallBack<T, X, Y, Z, W>;
            if (callback == null)
            {
                throw new Exception(String.Format("广播事件错误，事件{0}具有不同的委托类型", eventType));
            }
            else
            {
                callback(arg, arg2, arg3, arg4, arg5);
            }
        }
    }
    #endregion
}
