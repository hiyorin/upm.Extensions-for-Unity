using UnityEngine;

namespace UnityExtensions
{
    /// <summary>
    /// Transform extensions.
    /// </summary>
    public static class TransformExtensions
    {
        public static void SetPositionX(this Transform self, float x)
        {
            self.position = new Vector3(x, self.position.y, self.position.z);
        }

        public static void SetPositionY(this Transform self, float y)
        {
            self.position = new Vector3(self.position.x, y, self.position.z);
        }

        public static void SetPositionZ(this Transform self, float z)
        {
            self.position = new Vector3(self.position.x, self.position.y, z);
        }

        public static void AddPositionX(this Transform self, float x)
        {
            self.SetPositionX(x + self.position.x);
        }

        public static void AddPositionY(this Transform self, float y)
        {
            self.SetPositionY(y + self.position.y);
        }

        public static void AddPositionZ(this Transform self, float z)
        {
            self.SetPositionZ(z + self.position.z);
        }

        public static void SetLocalPositionX(this Transform self, float x)
        {
            self.localPosition = new Vector3(x, self.localPosition.y, self.localPosition.z);
        }

        public static void SetLocalPositionY(this Transform self, float y)
        {
            self.localPosition = new Vector3(self.localPosition.x, y, self.localPosition.z);
        }

        public static void SetLocalPositionZ(this Transform self, float z)
        {
            self.localPosition = new Vector3(self.localPosition.x, self.localPosition.y, z);
        }

        public static void AddLocalPositionX(this Transform self, float x)
        {
            self.SetLocalPositionX(x + self.localPosition.x);
        }

        public static void AddLocalPositionY(this Transform self, float y)
        {
            self.SetLocalPositionY(y + self.localPosition.y);
        }

        public static void AddLocalPositionZ(this Transform self, float z)
        {
            self.SetLocalPositionZ(z + self.localPosition.z);
        }

        public static void SetEulerAngleX(this Transform self, float x)
        {
            self.eulerAngles = new Vector3(x, self.eulerAngles.y, self.eulerAngles.z);
        }

        public static void SetEulerAngleY(this Transform self, float y)
        {
            self.eulerAngles = new Vector3(self.eulerAngles.x, y, self.eulerAngles.z);
        }

        public static void SetEulerAngleZ(this Transform self, float z)
        {
            self.eulerAngles = new Vector3(self.eulerAngles.x, self.eulerAngles.y, z);
        }

        public static void AddEulerAngleX(this Transform self, float x)
        {
            self.SetEulerAngleX(self.eulerAngles.x + x);
        }

        public static void AddEulerAngleY(this Transform self, float y)
        {
            self.SetEulerAngleY(self.eulerAngles.y + y);
        }

        public static void AddEulerAngleZ(this Transform self, float z)
        {
            self.SetEulerAngleZ(self.eulerAngles.z + z);
        }

        public static void SetLocalEulerAngleX(this Transform self, float x)
        {
            self.localEulerAngles = new Vector3(x, self.localEulerAngles.y, self.localEulerAngles.z);
        }

        public static void SetLocalEulerAngleY(this Transform self, float y)
        {
            self.localEulerAngles = new Vector3(self.localEulerAngles.x, y, self.localEulerAngles.z);
        }

        public static void SetLocalEulerAngleZ(this Transform self, float z)
        {
            self.localEulerAngles = new Vector3(self.localEulerAngles.x, self.localEulerAngles.y, z);
        }

        public static void AddLocalEulerAngleX(this Transform self, float x)
        {
            self.SetLocalEulerAngleX(self.localEulerAngles.x + x);
        }

        public static void AddLocalEulerAngleY(this Transform self, float y)
        {
            self.SetLocalEulerAngleY(self.localEulerAngles.y + y);
        }

        public static void AddLocalEulerAngleZ(this Transform self, float z)
        {
            self.SetLocalEulerAngleZ(self.localEulerAngles.z + z);
        }

        public static void SetLocalScaleX(this Transform self, float x)
        {
            self.localScale = new Vector3(x, self.localScale.y, self.localScale.z);
        }

        public static void SetLocalScaleY(this Transform self, float y)
        {
            self.localScale = new Vector3(self.localScale.x, y, self.localScale.z);
        }

        public static void SetLocalScaleZ(this Transform self, float z)
        {
            self.localScale = new Vector3(self.localScale.x, self.localScale.y, z);
        }

        public static void AddLocalScaleX(this Transform self, float x)
        {
            self.SetLocalScaleX(self.localScale.x + x);
        }

        public static void AddLocalScaleY(this Transform self, float y)
        {
            self.SetLocalScaleY(self.localScale.y + y);
        }

        public static void AddLocalScaleZ(this Transform self, float z)
        {
            self.SetLocalScaleZ(self.localScale.z + z);
        }

        public static void Reset(this Transform self)
        {
            self.localPosition = Vector3.zero;
            self.localScale = Vector3.one;
            self.localRotation = Quaternion.identity;
        }
    }
}
