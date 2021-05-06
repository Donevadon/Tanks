using UnityEngine;

namespace TanksLibrary
{
    public static class Extensions
    {
        public static Vector3 AngleParse(this Vector2 vector2,Vector2 target)
        {
            Vector3 diff = target - vector2;
            diff.Normalize();
 
            float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            return new Vector3(0f, 0f, rotZ - 90);
        }
    }
}