using Level;
using Saving;
using TMPro;
using UnityEngine;
using Zenject;


namespace Menu
{
    public class NewGameController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        private IInputHandler _inputHandler;
        private ILevelService _levelService;
        private MenuService _menuService;
        private ISavingService _savingService;

        [Inject]
        public void Construct(IInputHandler inputHandler, 
            ILevelService levelService, MenuService menuService, ISavingService savingService)
        {
            _inputHandler = inputHandler;
            _levelService = levelService;
            _menuService = menuService;
            _savingService = savingService;
        }

        private void OnEnable()
        {
            _inputHandler.KeyDown += OnKeyDown;
        }

        private void OnDisable()
        {
            _inputHandler.KeyDown -= OnKeyDown;
        }

        private void OnKeyDown(KeyCode keyCode)
        {
            if (keyCode == KeyCode.KeypadEnter)
            {
                _inputHandler.KeyDown -= OnKeyDown;
                string text = _inputField.text;
                _savingService.MakeNewSave(text.Length > 0 ? text : null);
                _levelService.LoadGame();
            }
            else if (keyCode == KeyCode.Escape) 
            { 
                _menuService.ChangeMode(Mode.MainMenu);
            }
        }
    }
}
