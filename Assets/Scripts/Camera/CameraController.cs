using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

namespace Kenshi.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private CinemachineVirtualCamera _camera;

        private List<ICameraHandler> _handlers = new();
        public Transform Target => _target;
        public CinemachineVirtualCamera Camera => _camera;

        private void Awake()
        {
            _handlers = GetComponents<ICameraHandler>().ToList();
            _handlers.ForEach(x => x.Init(this));
        }

        private void Update()
        {
            _handlers.ForEach(x => x.Execute());
        }
    }
}
