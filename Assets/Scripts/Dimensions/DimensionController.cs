using System;
using Dimensions.Type;
using Enums;
using Interfaces;
using Signals.Game;
using Signals.Player;
using Signals.Selected;
using Zenject;

namespace Dimensions
{
    public class DimensionController : IInitializable, IDisposable, ITickable
    {
        private IDimensions _currentDimensions;

        private bool _isTick;

        private readonly SignalBus _signal;
        private readonly Prismaglass _prismaglass;

        public DimensionController(SignalBus signal, Prismaglass prismaglass)
        {
            _signal = signal;
            _prismaglass = prismaglass;
        }

        public void Initialize()
        {
            _signal.Subscribe<PlayGameSignal>(OnPlay);
            _signal.Subscribe<RestartSignal>(OnRestart);
            _signal.Subscribe<MenuSignal>(OnMenu);
            
            _signal.Subscribe<RunStateSignal>(OnRun);
            _signal.Subscribe<PlayerWinSignal>(OnPlayerWin);
            
            _signal.Subscribe<SelectDimensionsSignal>(OnSelectDimension);
        }
        
        public void Tick()
        {
           if(!_isTick) return;
           _currentDimensions.Update();
        }
        
        public void Dispose()
        {
            _signal.Unsubscribe<PlayGameSignal>(OnPlay);
            _signal.Unsubscribe<RestartSignal>(OnRestart);
            
            _signal.Unsubscribe<PlayerWinSignal>(OnPlayerWin);
            _signal.Unsubscribe<RunStateSignal>(OnRun);
            
            _signal.Unsubscribe<SelectDimensionsSignal>(OnSelectDimension);
        }
        
        private void OnPlayerWin()
        {
            _isTick = false;
        }
        
        private void OnMenu()
        {
            
        }
        
        private void OnRestart()
        {
            
        }
        
        private void OnRun()
        {
            _currentDimensions.StartSpawn();
            _isTick = true;
        }
        
        private void OnPlay()
        {
            
        }
        
        private void OnSelectDimension(SelectDimensionsSignal signal)
        {
            var type = signal.DimensionType;
            switch (type)
            {
                case DimensionType.Electronicsia:
                    break;
                
                case DimensionType.None:
                    break;
                
                case DimensionType.Crystalium:
                    break;
                
                case DimensionType.Cybermatrix:
                    break;
                
                case DimensionType.Desertkin:
                    break;
                
                case DimensionType.Fantastronia:
                    break;
                
                case DimensionType.Forestmiria:
                    break;
                
                case DimensionType.Freerunia:
                    break;
                
                case DimensionType.Neonium:
                    break;
                
                case DimensionType.Steampunktica:
                    break;
                
                case DimensionType.Prismaglass:
                    _currentDimensions = _prismaglass;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            _currentDimensions.Loading();
        }
    }
}