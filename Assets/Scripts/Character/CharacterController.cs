using UnityEngine;

namespace Kenshi.Character
{
    public class CharacterController : MonoBehaviour
    {
        private UnityEngine.Camera _camera;
        private Character _character;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
            Character.OnSelect += HandleSelect;
        }

        private void OnDestroy()
        {
            Character.OnSelect -= HandleSelect;
        }

        private void HandleSelect(Character character)
        {
            _character = character;
        }

        private void Update()
        {
            if(_character == null)
                return;

            if(!Input.GetButtonDown("Fire2")) 
                return;
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit)) 
                return;
            
            _character.MoveTo(hit.point);
        }
    }
}
