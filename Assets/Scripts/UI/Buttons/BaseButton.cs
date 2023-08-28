using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton<T> : MonoBehaviour where T : struct
    {
        protected Button _button;
        protected SignalBus _signal;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signal = signalBus;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick()
        {
            _signal.Fire<T>();
        }
    }
}