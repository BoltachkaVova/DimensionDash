using System;
using Interfaces;
using UnityEngine;

namespace Player.PlayerStateMachine.State
{
    public class RunState : IState
    {
        private float _downPositionX;

        private Vector3 _targetPosition;

        private readonly PlayerAnimator _animator;
        private readonly Player _player;
        private readonly Settings _settings;

        public RunState(PlayerAnimator animator, Player player, Settings settings)
        {
            _animator = animator;
            _player = player;
            _settings = settings;
        }

        public void Enter()
        {
            _animator.StartRunning();
            _targetPosition = _player.transform.position;
        }

        public void Update()
        {
            if (_player.transform.position != _targetPosition)
                _player.transform.position = Vector3.MoveTowards(_player.transform.position, _targetPosition,
                    _settings.Speed * Time.deltaTime);
            
            if (Input.GetMouseButtonDown(0))
                _downPositionX = Input.mousePosition.x;

            if (!Input.GetMouseButtonUp(0)) return;
            
            var upPositionX = Input.mousePosition.x;
            if (_downPositionX < upPositionX)
                MoveToRight();
            else
                MoveToLeft();
        }

        public void Exit()
        {
            
        }
        

        private void MoveToRight()
        {
            if(_targetPosition.x >= _settings.MAXRight) return;
            SetTargetPosition(_settings.StepSize);
        }

        private void MoveToLeft()
        {
            if(_targetPosition.x <= _settings.MAXLeft) return;
            SetTargetPosition(-_settings.StepSize);
        }

        private void SetTargetPosition(float stepSize)
        {
            _targetPosition = new Vector3(_targetPosition.x + stepSize, _targetPosition.y, _targetPosition.z);
        }
        
        [Serializable]
        public class Settings
        {
            [SerializeField] private float speed;
            [SerializeField] private float stepSize;
        
            [Header("Travel Range")]
            [SerializeField] private float maxRight;
            [SerializeField] private float maxLeft;

            public float Speed => speed;
            public float StepSize => stepSize;

            public float MAXRight => maxRight;
            public float MAXLeft => maxLeft;
        }
    }
}