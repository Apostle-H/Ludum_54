using UnityEngine;

namespace Utils.Camera
{
    public static class CameraService
    {
        private static UnityEngine.Camera _camera;
        
        static CameraService() => _camera = UnityEngine.Camera.current;

        public static void UpdateCamera() => _camera = UnityEngine.Camera.main;

        public static Vector2 ScreenToWorldPoint(Vector2 screenPoint) => _camera.ScreenToWorldPoint(screenPoint);
    }
}