using UnityEngine;

namespace UnityExtensions
{
    public static class SpriteRendererExtensions
    {
        public static void SetColorRed(this SpriteRenderer self, float value)
        {
            self.color = new Color(value, self.color.g, self.color.b, self.color.a);
        }

        public static void SetColorGreen(this SpriteRenderer self, float value)
        {
            self.color = new Color(self.color.r, value, self.color.b, self.color.a);
        }

        public static void SetColorBlue(this SpriteRenderer self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, value, self.color.b);
        }

        public static void SetColorAlpha(this SpriteRenderer self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, self.color.b, value);
        }
    }
}
