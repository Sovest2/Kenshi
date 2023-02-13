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
        public static event Action<Character> OnSelect;
        
        [Header("States")]
        public Idle IdleState;
        public Move MoveState;
        
        
        private FocusTarget _focusTarget;
        public Animator Animator { get; private set; }
        public NavMeshAgent Agent { get; private set; }
        public State CurrentState { get; private set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
            _focusTarget = GetComponent<FocusTarget>();

            FocusTarget.OnSelect += HandleFocus;
            ChangeState(IdleState);
        }

        private void OnDestroy()
        {
            FocusTarget.OnSelect -= HandleFocus;
        }

        private void Update()
        {
            CurrentState.Update();
        }

        private void FixedUpdate()
        {
            CurrentState.FixedUpdate();
        }
        
        public void ChangeState(State newState)
        {
            CurrentState?.Exit();
            
            CurrentState = newState;
            CurrentState.Enter(this);
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
    }
}
