using Signals.Player;
using UnityEngine;

namespace Triggers
{
    public class FinishTrigger : BaseTrigger
    {
        private bool _isActive = true;
        private void Update()
        {
            if(!_isActive) return;
            transform.Translate(Vector3.back * (_speed * Time.deltaTime));
        }
        protected override void PlayerEnter()
        {
            _isActive = false;
            _signal.Fire<PlayerWinSignal>();
        }
    }
}