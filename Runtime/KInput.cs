using UnityEngine;

namespace kroon.Utils.Input
{
    public static class KInput
    {
        public static Vector3 PointerToWorldPosition(this Camera camera, Camera.MonoOrStereoscopicEye eye = default)
        {
            var mousePos = UnityEngine.Input.mousePosition;
            return camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane), eye);
        }

        public static Vector3 PointerToWorldPosition(this Camera camera) =>
            PointerToWorldPosition(camera, default);
    }
}