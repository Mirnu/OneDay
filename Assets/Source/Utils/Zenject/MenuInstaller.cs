using Level;
using Menu;
using UnityEngine;
using Zenject;

namespace Installers 
{
    public class MenuInstaller : MonoInstaller
    {
        [Header("Modes")]
        [SerializeField] private GameObject _mainMode;
        [SerializeField] private GameObject _newGameMode;
        [SerializeField] private GameObject _savingMode;

        [Header("Other")]
        [SerializeField] private ContinueGameButton _continueGameButton;
        [SerializeField] private NewGameButton _newGameButton;
        [SerializeField] private GameObject _gameObject;

        public override void InstallBindings()
        {
            bindMain();
            bindMainMenuMode();
            bindNewGameMode();
        }

        private void bindMain()
        {
            Container.Bind<GameObject>().WithId("mainMode").FromInstance(_mainMode);
            Container.Bind<GameObject>().WithId("savingMode").FromInstance(_savingMode);
            Container.Bind<GameObject>().WithId("newGameMode").FromInstance(_newGameMode);

            Container.BindInterfacesAndSelfTo<MenuService>().AsSingle().NonLazy();
        }

        private void bindMainMenuMode()
        {
            Container.BindInterfacesAndSelfTo<ContinueGameButton>().FromInstance(_continueGameButton);
            Container.BindInterfacesAndSelfTo<NewGameButton>().FromInstance(_newGameButton);
        }

        private void bindNewGameMode()
        {
            Container.BindInterfacesAndSelfTo<NewGameController>().AsSingle().NonLazy();
        }
    }
}
