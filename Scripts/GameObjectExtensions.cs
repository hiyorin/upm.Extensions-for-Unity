using UnityEngine;
using System.Collections.Generic;

namespace UnityExtensions
{
    /// <summary>
    /// GameObject extensions.
    /// </summary>
    public static class GameObjectExtensions
    {
        public static void SetActiveSafe(this GameObject self, bool value)
        {
            if (self.activeSelf != value)
            {
                self.SetActive(value);
            }
        }

        public static T GetComponentInParentAndChildren<T>(this GameObject self)
        {
            if(self.GetComponentInParent<T>() != null)
            {
                return self.GetComponentInParent<T>();
            }

            if(self.GetComponentInChildren<T>() != null)
            {
                return self.GetComponentInChildren<T>();
            }

            return self.GetComponent<T>();
        }
        
        public static List<T> GetComponentsInParentAndChildren<T>(this GameObject self) where T : Component
        {
            List<T> _list = new List<T>(self.GetComponents<T>());

            _list.AddRange(new List<T>(self.GetComponentsInChildren<T>()));
            _list.AddRange(new List<T>(self.GetComponentsInParent<T>()));

            return _list;
        }
    }
}
