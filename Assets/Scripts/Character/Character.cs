using System;
using Kenshi.Character.States;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Kenshi.Character
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(FocusTarget))]
    public class Character : MonoBehaviour, IPointerClickHandler
    {
        private static readonly int Move = Animator.StringToHash("Move");
        public static event Action<Character> OnSelect;
        
        private FocusTarget _focusTarget;
        private Animator _animator;
        private MoveBehaviour _moveBehaviour;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _moveBehaviour = _animator.GetBehaviour<MoveBehaviour>();
            _focusTarget = GetComponent<FocusTarget>();

            FocusTarget.OnSelect += HandleFocus;
        }

        private void OnDestroy()
        {
            FocusTarget.OnSelect -= HandleFocus;
        }

        private void HandleFocus(FocusTarget focusTarget)
        {
            if(!_focusTarget.Equals(focusTarget))
                return;
            
            OnSelect?.Invoke(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(!eventData.button.Equals(PointerEventData.InputButton.Left))
                return;
            
            OnSelect?.Invoke(this);
        }

        public void MoveTo(Vector3 position)
        {
            _animator.SetTrigger(Move);
            _moveBehaviour.SetDestination(position);
        }
    }
}
