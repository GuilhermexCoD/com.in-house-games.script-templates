using System.Collections.Generic;
using UnityEngine;

namespace RaizoLib.UnityUtils
{
    public static class ComponentExtensions
    {

        /// <summary>
        /// Like GetComponentInChildren, but do a breadth first search instead.
        /// </summary>
        public static T BfsGetComponentInChildren<T>(this Component behaviour) where T : Component
        {
            List<Transform> frontier = new() { behaviour.transform };
            while (frontier.Count > 0)
            {
                Transform f = frontier[0];
                frontier.RemoveAt(0);
                foreach (Transform child in f)
                {
                    if (child.TryGetComponent(out T result))
                    {
                        return result;
                    }
                    frontier.Add(child);
                }
            }
            return null;
        }

        /// <summary>
        /// Like GetComponentInChildren<T>, but with an not null assertion.
        /// </summary>
        public static T RequireComponentInChildren<T>(this Component component, bool includeInactive = false)
        {
            T result = component.GetComponentInChildren<T>(includeInactive);
            Debug.Assert(result != null, $"No child of type {typeof(T)} found in `{component.name}' tree.", component);
            return result;
        }

        /// <summary>
        /// Like GetComponentInParent<T>, but with an not null assertion.
        /// </summary>
        public static T RequireComponentInParent<T>(this Component component, bool includeInactive = false)
        {
            T result = component.GetComponentInParent<T>(includeInactive);
            Debug.Assert(result != null, $"No parent of type {typeof(T)} found in `{component.name}' tree.", component);
            return result;
        }

        /// <summary>
        /// Like GetComponent<T>, but with an not null assertion.
        /// </summary>
        public static T RequireComponent<T>(this Component component)
        {
            T result = component.GetComponent<T>();
            Debug.Assert(result != null, $"No component of type {typeof(T)} found in `{component.name}'.", component);
            return result;
        }
    }
}
