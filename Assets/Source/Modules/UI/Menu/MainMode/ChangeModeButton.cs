using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu
{
    public class ChangeModeButton : MonoBehaviour
    {
        [SerializeField] private Mode _mode;
        private MenuService _menuService;
        private Button _button;

        [Inject]
        public void Construct(MenuService menuService)
        {
            _menuService = menuService;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _menuService.ChangeMode(_mode);
        }
    }
}