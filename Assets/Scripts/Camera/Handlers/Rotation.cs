using UnityEngine;

namespace Kenshi.Camera
{
    public class Rotation : MonoBehaviour, ICameraHandler
    {
        [SerializeField] private float _xSensitivity;
        [SerializeField] private bool _xInverse;
        
        [Space]
        [SerializeField] private float _ySensitivity;
        [SerializeField] private bool _yInverse;

        private CameraController _controller;
        
        public void Init(CameraController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            HandleMouseRotation();
        }

        private void HandleMouseRotation()
        {
            if (!Input.GetButton("Fire2")) return;

            float xInput = Input.GetAxis("Mouse X") * _xSensitivity * (_xInverse ? -1 : 1);
            float yInput = Input.GetAxis("Mouse Y") * _ySensitivity * (_yInverse ? -1 : 1);
            
            Rotate(xInput, yInput);
        }
        
        private void Rotate(float x, float y)
        {
            var rotation = _controller.Target.eulerAngles;
            rotation.y += x;
            rotation.x += y;

            _controller.Target.eulerAngles = rotation;
        }
    }
}
