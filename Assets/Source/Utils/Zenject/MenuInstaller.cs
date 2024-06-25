using Level;
using Menu;
using System.Collections.Generic;
using TMPro;
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

        [Header("Main menu")]
        [SerializeField] private ContinueGameButton _continueGameButton;
        [SerializeField] private List<ChangeModeButton> _changeModeButtons;

        [Header("NewGame Menu")]
        [SerializeField] private NewGameController _newGameController;

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

            foreach (var button in _changeModeButtons)
            {
                Container.BindInterfacesAndSelfTo<ChangeModeButton>().FromInstance(button);
            }
        }

        private void bindNewGameMode()
        {
            Container.BindInterfacesAndSelfTo<NewGameController>().FromInstance(_newGameController);   
        }
    }
}
