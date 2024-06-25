using Dialogue;
using Model;
using Movement;
using Poll;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private Character _character;
        [SerializeField] private DialogueView _dialogueView;
        [SerializeField] private PollView _pollview;
        [SerializeField] private Test test;

        public override void InstallBindings()
        {
            bindPlayer();
            bindMovement();
            bindPoll();
            bindDialog();
            Container.BindInterfacesAndSelfTo<Test>().FromInstance(test).NonLazy();
        }

        private void bindPlayer()
        {
            Character character = Container.InstantiatePrefabForComponent<Character>(_character);
            Container.BindInterfacesAndSelfTo<Character>().FromInstance(character);
        }

        private void bindMovement()
        {
            Container.Bind<IMovement>().To<WalkMovement>().AsSingle().NonLazy();
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
}