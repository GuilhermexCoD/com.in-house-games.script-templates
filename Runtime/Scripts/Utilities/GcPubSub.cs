using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;


/// <summary>
/// Garbage collected publish and subscribe methods
/// Purpose is to subscribe to events and not worry about subscribers being destroyed.
/// </summary>
public static class GcPubSub
{
    public static void SubscribeEv(List<(Object owner, Action cb)> subscribers, Object owner, Action cb)
    {
        subscribers.Add((owner, cb));
    }

    public static void SubscribeEv<T>(List<(Object owner, Action<T> cb)> subscribers, Object owner, Action<T> cb)
    {
        subscribers.Add((owner, cb));
    }

    public static void Notify(List<(Object owner, Action cb)> subscribers)
    {
        for (int i = 0; i < subscribers.Count; i += 1)
        {
            var (owner, cb) = subscribers[i];
            // check if owner is valid and remove it if not
            if (owner)
            {
                cb();
            }
            else
            {
                subscribers.RemoveAt(i);
                i -= 1;
            }
        }
    }

    public static void Notify<T>(List<(Object owner, Action<T> cb)> subscribers, T value)
    {
        for (int i = 0; i < subscribers.Count; i += 1)
        {
            var (owner, cb) = subscribers[i];
            // check if owner is valid and remove it if not
            if (owner)
            {
                cb(value);
            }
            else
            {
                subscribers.RemoveAt(i);
                i -= 1;
            }
        }
    }
}