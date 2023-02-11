using UnityEngine;

namespace Kenshi.Camera
{
    public class Focus : MonoBehaviour, ICameraHandler
    {
        [SerializeField] private FocusTarget _target;
        
        private CameraController _controller;
        public void Init(CameraController controller)
        {
            _controller = controller;
            FocusTarget.OnSelect += SelectTarget;
        }

        public void Execute()
        {
            if(_target == null)
                return;

            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            {
                _target = null;
                return;
            }

            _controller.Target.position = _target.transform.position;
        }

        private void SelectTarget(FocusTarget target)
        {
            _target = target;
        }
    }
}
