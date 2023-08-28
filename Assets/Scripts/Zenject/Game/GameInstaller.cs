using DimensionDash;
using Dimensions;
using Dimensions.Type;
using Zenject;

public class GameInstaller : Installer<GameInstaller>
{
    public override void InstallBindings()
    {
        BindDimensions();
        
        Container.BindInterfacesAndSelfTo<GameEngine>().AsSingle().NonLazy();
    }

    private void BindDimensions()
    {
        Container.Bind<Prismaglass>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<DimensionController>().AsSingle().NonLazy();
    }
}