using Signals.Game;
using Signals.Player;
using Signals.Selected;
using UI.Panels;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private LoadingPanel loadingPanel;
        [SerializeField] private WinPanel winPanel;
        [SerializeField] private DimensionPanel dimensionPanel;
        
        private BasePanel _currentPanel;
        private SignalBus _signal;

        [Inject]
        public void Construct(SignalBus signal)
        {
            _signal = signal;
        }

        private void Start()
        {
            _signal.Subscribe<PlayGameSignal>(OnPlay);
            _signal.Subscribe<PlayerWinSignal>(OnWin);
            _signal.Subscribe<SelectDimensionsSignal>(OnSelectDimension);
            
             _currentPanel = dimensionPanel;
             _currentPanel.Open();
        }
        
        private void OnDestroy()
        { 
            _signal.Unsubscribe<PlayGameSignal>(OnPlay);   
            _signal.Unsubscribe<PlayerWinSignal>(OnWin);
            _signal.Unsubscribe<SelectDimensionsSignal>(OnSelectDimension);
        }
        
        private async void ChangePanel(BasePanel panel)
        {
            await _currentPanel.Close();
             _currentPanel = panel;
            await _currentPanel.Open();
        }
        
        private void OnSelectDimension()
        {
            ChangePanel(loadingPanel);
        }
        
        private void OnWin()
        { 
            ChangePanel(winPanel);   
        }
        
        private void OnPlay()
        {
           ChangePanel(gamePanel);   
        }
        
    }
}