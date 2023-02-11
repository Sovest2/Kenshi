using Cinemachine;
using UnityEngine;

namespace Kenshi.Camera
{
    public class Zoom : MonoBehaviour, ICameraHandler
    {
        [SerializeField] private float _zoomSpeed;
        [SerializeField] private float _minimalZoom;
        [SerializeField] private float _maximumZoom;
        
        [Space]
        [SerializeField] private bool _zoomInverse;
        
        private CinemachineTransposer _transposer;

        public void Init(CameraController controller)
        {
            _transposer = controller.Camera.GetCinemachineComponent<CinemachineTransposer>();
        }

        public void Execute()
        {
            HandleZoom();
        }

        private void HandleZoom()
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            Vector3 offset = _transposer.m_FollowOffset;
                
            offset.z += scrollDelta * _zoomSpeed * 1000 * Time.deltaTime * (_zoomInverse ? -1 : 1);
            offset.z = Mathf.Clamp(offset.z, -_maximumZoom, -_minimalZoom);
            _transposer.m_FollowOffset = offset;
        }

        
    }
}
