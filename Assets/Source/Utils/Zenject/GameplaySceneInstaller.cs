using Dialogue;
using Model;
using Movement;
using Poll;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Character _character;
    [SerializeField] private DialogueView _dialogueView;
    [SerializeField] private PollView _pollview;
    [SerializeField] private Test test;

    public override void InstallBindings()
    {
        bindInput();
        bindPlayer();
        bindMovement();
        bindModels();
        bindPoll();
        bindDialog();
        Container.BindInterfacesAndSelfTo<Test>().FromInstance(test).NonLazy();
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
        Container.Bind<IMovement>().To<WalkMovement>().AsSingle().NonLazy();
    }

    private void bindModels()
    {
        Container.BindInterfacesAndSelfTo<DialogsModel>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ChoisesModel>().AsSingle().NonLazy();
    }

    private void bindPoll()
    {
        Container.Bind<IPollService>().To<PollView>().FromInstance(_pollview);
    }

    private void bindDialog()
    {
        Container.BindInterfacesAndSelfTo<DialogueView>().FromInstance(_dialogueView);
        Container.Bind<IDialogueService>().To<DialogueService>().AsSingle().NonLazy();
    }
}