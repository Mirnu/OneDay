using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public enum Mode
    {
        MainMenu,
        Saving,
    }

    public class MenuService : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMode;
        [SerializeField] private GameObject _savingMode;

        private Dictionary<Mode, GameObject> _modes = new();
        private GameObject _currentMode;

        private void Awake()
        {
            _modes.Add(Mode.MainMenu, _mainMode);
            _modes.Add(Mode.Saving, _savingMode);
            enableMode(_mainMode);
        }

        public void ChangeMode(Mode mode)
        {
            _currentMode.SetActive(false);
            enableMode(_modes[mode]);
        }

        private void enableMode(GameObject mode)
        {
            _currentMode = mode;
            _currentMode.SetActive(true);
        }
    }
}