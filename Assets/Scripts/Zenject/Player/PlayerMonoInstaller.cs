using Player;
using UnityEngine;
using Zenject;

public class PlayerMonoInstaller : MonoInstaller
{
    [SerializeField] private Animator animator;
    public override void InstallBindings()
    {
        Container.Bind<Player.Player>().FromInstance(GetComponent<Player.Player>()).AsSingle().NonLazy();
        Container.Bind<PlayerAnimator>().AsSingle().WithArguments(animator);
        
        PlayerInstaller.Install(Container);
    }
}