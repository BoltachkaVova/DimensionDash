using System;
using Interfaces;
using Player.PlayerStateMachine.State;
using Signals.Game;
using Signals.Player;
using Zenject;

namespace Player.PlayerStateMachine
{
    public class PlayerStateMachine : IInitializable, ITickable, IDisposable
    {
        private bool _isTick = false;
        
        private IState _currentState;

        private readonly SignalBus _signal;
        private readonly RunState _runState;
        private readonly FlightState _flightState;
        private readonly IdleState _idleState;
        private readonly WinState _winState;

        public PlayerStateMachine(SignalBus signal, RunState runState, FlightState flightState,
            IdleState idleState, WinState winState)
        {
            _signal = signal;
            
            _runState = runState;
            _flightState = flightState;
            _idleState = idleState;
            _winState = winState;
        }

        public void Initialize()
        {
            _signal.Subscribe<RunStateSignal>(OnRunState);
            _signal.Subscribe<PlayGameSignal>(OnPlay);
            _signal.Subscribe<PlayerWinSignal>(OnPlayerWin);
        }
        

        public void Tick()
        {
            if(!_isTick) return;
            _currentState.Update();
        }

        public void Dispose()
        {
            _signal.Unsubscribe<RunStateSignal>(OnRunState);
            _signal.Unsubscribe<PlayGameSignal>(OnPlay);
            _signal.Unsubscribe<PlayerWinSignal>(OnPlayerWin);
        }

        private void ChangeState(IState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
        
        private void OnRunState()
        {
            ChangeState(_runState);
            _isTick = true;
        }
        
        private void OnPlayerWin()
        {
            _isTick = false;
            ChangeState(_winState);
        }
        
        private void OnPlay()
        {
            ChangeState(_idleState);
            _isTick = true;
        }
    }
}