using Interfaces;
using Signals.Player;
using UnityEngine;
using Zenject;

namespace Player.PlayerStateMachine.State
{
    public class IdleState : IState
    {
        private readonly SignalBus _signal;

        public IdleState(SignalBus signal)
        {
            _signal = signal;
        }

        public void Enter()
        {
         
        }

        public void Update()
        {
            if(Input.GetMouseButtonUp(0))
                _signal.Fire<RunStateSignal>();
        }

        public void Exit()
        {
           
        }
    }
}