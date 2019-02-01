using UnityEngine;
using System.Collections;

namespace UnityExtensions
{
    /// <summary>
    /// MonoBehaviour extensions.
    /// </summary>
    public static class MonoBehaviourExtensions
    {
        public static void StopCoroutineSafe(this MonoBehaviour self, ref IEnumerator coroutine)
        {
            if (coroutine != null)
            {
                self.StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        public static void StopCoroutineSafe(this MonoBehaviour self, ref Coroutine coroutine)
        {
            if (coroutine != null)
            {
                self.StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }
}
