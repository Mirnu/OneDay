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
        Character character = Container.InstantiatePrefabForComponent<Character>(_character);
        Container.BindInterfacesAndSelfTo<Character>().FromInstance(character);
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