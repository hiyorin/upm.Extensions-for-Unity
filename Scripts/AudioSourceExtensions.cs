using UnityEngine;

namespace UnityExtensions
{
    public static class AudioSourceExtensions
    {
        public static bool Play(this AudioSource self, AudioClip clip, float volume)
        {
            if (clip == null || volume <= 0.0f)
                return false;

            self.clip = clip;
            self.volume = volume;
            self.Play();
            return true;
        }
    }
}
