#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

namespace UnityExtensions.Editor
{
    internal static class OpenDirectory
    {
        [MenuItem("OpenDir/DataPath")]
        private static void OpenDataPath()
        {
            Process.Start(Application.dataPath);
        }

        [MenuItem("OpenDir/TemporaryCachePath")]
        private static void OpenTemporaryCachePath()
        {
            Process.Start(Application.temporaryCachePath);
        }

        [MenuItem("OpenDir/PersistentDataPath")]
        private static void OpenPersistentDataPath()
        {
            Process.Start(Application.persistentDataPath);
        }

        [MenuItem("OpenDir/StreamingAssetsPath")]
        private static void OpenStreamingAssetsPath()
        {
            Process.Start(Application.streamingAssetsPath);
        }

        [MenuItem("OpenDir/ApplicationPath")]
        private static void OpenApplicationPath()
        {
            Process.Start(EditorApplication.applicationPath);
        }

        [MenuItem("OpenDir/ApplicationContentsPath")]
        private static void OpenApplicationContentsPath()
        {
            Process.Start(EditorApplication.applicationContentsPath);
        }
    }
}
#endif
