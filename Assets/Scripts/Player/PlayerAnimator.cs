using UnityEngine;

namespace Player
{
    public class PlayerAnimator
    {
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int StartRun = Animator.StringToHash("StartRun");
        private static readonly int Victory = Animator.StringToHash("Victory");
        
        private readonly Animator _animator;
        
        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void StartRunning()
        {
            _animator.SetTrigger(StartRun);
        }

        public void Running()
        {
            _animator.SetTrigger(Run);
        }

        public void Win()
        {
            _animator.SetTrigger(Victory);
        }

    }
}