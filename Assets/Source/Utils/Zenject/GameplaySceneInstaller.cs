using Dialogue;
using Model;
using Movement;
using Poll;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Character _character;
    [SerializeField] private DialogueView _dialogueview;
    [SerializeField] private PollView _pollview;

    public override void InstallBindings()
    {
        bindInput();
        bindPlayer();
        bindMovement();
        bindModels();
        bindPoll();
        bindDialog();
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

    private void bindModels()
    {
        Container.BindInterfacesAndSelfTo<HistoryModel>().AsSingle().NonLazy();
    }

    private void bindPoll()
    {
        Container.BindInterfacesAndSelfTo<PollView>().FromInstance(_pollview);
    }

    private void bindDialog()
    {
        Container.BindInterfacesAndSelfTo<DialogueView>().FromInstance(_pollview);
        Container.BindInterfacesAndSelfTo<DialogueService>().AsSingle().NonLazy();
    }
}