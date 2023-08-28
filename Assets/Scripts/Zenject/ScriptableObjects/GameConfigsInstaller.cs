using System;
using Dimensions;
using Dimensions.Type;
using Player.PlayerStateMachine.State;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigsInstaller", menuName = "Configs/Game/GameConfigsInstaller")]
public class GameConfigsInstaller : ScriptableObjectInstaller<GameConfigsInstaller>
{
    [SerializeField] private PlayerSettings player;
    [SerializeField] private DimensionsSettings dimensions;
    [SerializeField] private UISettings UI;
    
    public override void InstallBindings()
    {
        BindingPlayerSettings();
        BindingDimensionsSettings();
        BindingUISettings();
    }

    private void BindingUISettings()
    {
        //Container.BindInstance(UI.panels).IfNotBound();
    }

    private void BindingPlayerSettings()
    {
        Container.BindInstance(player.runStateSettings).IfNotBound();
    }

    private void BindingDimensionsSettings()
    {
        Container.BindInstance(dimensions.prismaglass).IfNotBound();
    }


    [Serializable]
    public class DimensionsSettings
    {
        public Prismaglass.Settings prismaglass;
    }


    [Serializable]
    public class PlayerSettings
    {
        public RunState.Settings runStateSettings;
    }
    
    [Serializable]
    public class UISettings
    {
        
    }

    
}