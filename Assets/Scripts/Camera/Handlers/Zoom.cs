using Cinemachine;
using UnityEngine;

namespace Kenshi.Camera
{
    public class Zoom : MonoBehaviour, ICameraHandler
    {
        [SerializeField] private float _zoomSensitivity;
        [SerializeField] private float _minimalZoom;
        [SerializeField] private float _maximumZoom;
        
        [Space]
        [SerializeField] private bool _zoomInverse;

        private CinemachineTransposer _transposer;
        private float _currentOffset;

        public void Init(CameraController controller)
        {
            _transposer = controller.Camera.GetCinemachineComponent<CinemachineTransposer>();
            _currentOffset = -(_transposer.m_FollowOffset.z + _minimalZoom) / _maximumZoom;
        }

        public void Execute()
        {
            HandleZoom();
        }

        private void HandleZoom()
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel"); ;
            
            Vector3 offset = _transposer.m_FollowOffset;
            
            float input = scrollDelta * (_zoomInverse ? -1 : 1) * _zoomSensitivity;
            _currentOffset = Mathf.Clamp(_currentOffset + input, 0f, 1f);
            
            offset.z = Mathf.Lerp(-_minimalZoom, -_maximumZoom, _currentOffset );
            _transposer.m_FollowOffset = offset;
        }
    }
}
