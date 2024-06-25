using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Menu
{
    public enum Mode
    {
        MainMenu,
        NewGame,
        Saving,
    }

    public class MenuService : IInitializable
    {
        public MenuService([Inject(Id = "mainMode")] GameObject mainMode,
            [Inject(Id = "savingMode")] GameObject savingMode,
            [Inject(Id = "newGameMode")] GameObject newGameMode)
        {
            _modes.Add(Mode.MainMenu, mainMode);
            _modes.Add(Mode.Saving, savingMode);
            _modes.Add(Mode.NewGame, newGameMode);
        }

        private Dictionary<Mode, GameObject> _modes = new();
        private GameObject _currentMode;

        public void Initialize()
        {
            disableAll();
            enableMode(_modes[Mode.MainMenu]);
        }

        public void ChangeMode(Mode mode)
        {
            _currentMode.SetActive(false);
            enableMode(_modes[mode]);
        }

        private void disableAll()
        {
            foreach (var mode in _modes)
            {
                mode.Value.SetActive(false);
            }
        }

        private void enableMode(GameObject mode)
        {
            _currentMode = mode;
            _currentMode.SetActive(true);
        }
    }
}