using Movement;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Character _character;

    public override void InstallBindings()
    {
        bindInput();
        bindPlayer();
        bindMovement();
    }

    private void bindPlayer()
    {
        Container.InstantiatePrefab(_character, gameObject.transform);
    }

    private void bindInput()
    {
        Container.BindInterfacesAndSelfTo<KeyboardInput>().AsSingle();
    }

    private void bindMovement()
    {
        Container.BindInterfacesAndSelfTo<WalkMovement>().AsSingle().NonLazy();
    }
}