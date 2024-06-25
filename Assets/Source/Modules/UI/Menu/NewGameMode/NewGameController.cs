using Level;
using UnityEngine;
using Zenject;


namespace Menu
{
    public class NewGameController : IInitializable
    {
        private readonly IInputHandler _inputHandler;
        private readonly ILevelService _levelService;
        private readonly MenuService _menuService;

        public NewGameController(IInputHandler inputHandler, 
            ILevelService levelService, MenuService menuService)
        {
            _inputHandler = inputHandler;
            _levelService = levelService;
            _menuService = menuService;
        }

        public void Initialize()
        {
            _inputHandler.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(KeyCode keyCode)
        {
            if (keyCode == KeyCode.KeypadEnter)
            {
                _levelService.LoadGame();
            }
            else if (keyCode == KeyCode.Escape) 
            { 
                _menuService.ChangeMode(Mode.MainMenu);
                _inputHandler.KeyDown -= OnKeyDown;
            }
        }
    }
}
