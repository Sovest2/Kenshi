using System;
using System.Collections.Generic;
using Kenshi.Character.Commands;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Kenshi.Character
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(FocusTarget))]
    public class Character : MonoBehaviour, IPointerClickHandler
    {
        public static event Action<Character> OnSelect;

        public event Action<ICommand> OnCommandExecuted;
        public Queue<ICommand> Commands { get; } = new();
        
        private FocusTarget _focusTarget;
        public Animator Animator { get; private set; }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
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

        public void SetCommand(ICommand command)
        {
            Commands.Clear();
            AddCommand(command);
            ExecuteCommand();
        }

        public void AddCommand(ICommand command)
        {
            Commands.Enqueue(command);
        }

        public void ExecuteCommand()
        {
            if(Commands.Count <= 0) 
                return;

            ICommand command = Commands.Dequeue();
            if (command.Execute()) OnCommandExecuted?.Invoke(command);
        }
    }
}
