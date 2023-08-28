using Interfaces;

namespace Player.PlayerStateMachine.State
{
    public class WinState : IState
    {
        private readonly PlayerAnimator _animator;

        public WinState(PlayerAnimator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            _animator.Win();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}