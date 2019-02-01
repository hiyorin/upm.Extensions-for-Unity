using UnityEngine;

namespace UnityExtensions
{
    public static class MaterialExtensions
    {
        public static void SetColorRed(this Material self, float value)
        {
            self.color = new Color(value, self.color.g, self.color.b, self.color.a);
        }

        public static void SetColorGreen(this Material self, float value)
        {
            self.color = new Color(self.color.r, value, self.color.b, self.color.a);
        }

        public static void SetColorBlue(this Material self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, value, self.color.b);
        }

        public static void SetColorAlpha(this Material self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, self.color.b, value);
        }
    }
}
