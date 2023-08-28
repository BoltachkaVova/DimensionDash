using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ProjectInstaller.Install(Container);
        SignalBusInstaller.Install(Container);
        SignalsInstaller.Install(Container);
    }
}