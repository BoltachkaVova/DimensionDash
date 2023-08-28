using Enums;
using Signals.Selected;
using UnityEngine;

namespace UI.Buttons.Select
{
    public class SelectDimensionButton : BaseButton<SelectDimensionsSignal>
    {
        [SerializeField] private DimensionType type;
        [SerializeField] private bool isActive;
        
        private void Start()
        {
            _button.interactable = isActive;
        }

        protected override void OnClick()
        {
            _signal.Fire(new SelectDimensionsSignal(type));
        }
    }
}