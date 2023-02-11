using System;
using UnityEngine;

namespace Kenshi.Camera
{
    public class Movement : MonoBehaviour, ICameraHandler
    {
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _speed;
        
        [Space]
        [SerializeField] private bool _mouseMovement;
        [SerializeField, Range(0, 0.5f)] private float _screenEdgeOffset;
        
        private CameraController _controller;
        
        public void Init(CameraController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            HandleKeyboardMovement();
            HandleMouseMovement();
        }

        private void HandleKeyboardMovement()
        {
            var input = Vector3.zero;
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
            
            if(input.Equals(Vector3.zero)) return;
            
            Move(input);
        }
        
        private void HandleMouseMovement()
        {
            if (!_mouseMovement) return;
            
            var input = Vector3.zero;
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            var mousePosition = Input.mousePosition;
            
            if (mousePosition.y >= screenHeight * (1 - _screenEdgeOffset))
                input.z = 1;
            else if (mousePosition.y <= screenHeight * _screenEdgeOffset)
                input.z = -1;

            if (mousePosition.x >= screenWidth * (1 - _screenEdgeOffset))
                input.x = 1;
            else if (mousePosition.x <= screenWidth * _screenEdgeOffset)
                input.x = -1;
            
            if(input.Equals(Vector3.zero)) return;
            
            Move(input);
        }

        private void Move(Vector3 input)
        {
            // Perform move
            Vector3 movement = Quaternion.Euler(0, _controller.Target.eulerAngles.y, 0) * input;
            _controller.Target.Translate(movement * (_speed * Time.deltaTime), Space.World);
            
            // Stick to ground
            RaycastHit hit;
            Vector3 targetPosition = _controller.Target.position;
            targetPosition.y += 5;

            if (Physics.Raycast(targetPosition, Vector3.down, out hit,Mathf.Infinity, _groundMask))
            {
                _controller.Target.position = hit.point;
            }
        }
    }
}
