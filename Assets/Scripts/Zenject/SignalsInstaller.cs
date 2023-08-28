using Signals.Game;
using Signals.Player;
using Signals.Selected;
using Zenject;

public class SignalsInstaller : Installer<SignalsInstaller>
{
    public override void InstallBindings()
    {
        PlayerSignals();
        GameSignals();
        SelectedSignals();
    }

    private void SelectedSignals()
    {
        Container.DeclareSignal<SelectDimensionsSignal>();
        Container.DeclareSignal<SelectPlayerSignal>();
    }


    private void PlayerSignals()
    {
        Container.DeclareSignal<RunStateSignal>(); // когда начинает игрок бежать
        Container.DeclareSignal<PlayerWinSignal>(); 
    }

    private void GameSignals()
    {
        Container.DeclareSignal<PlayGameSignal>();
        Container.DeclareSignal<RestartSignal>();
        Container.DeclareSignal<MenuSignal>();
    }
}