using Saving;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class ContinueGameButton : MonoBehaviour
    {
        private ISavingService _savingService;

        [Inject]
        public void Construct(ISavingService savingService)
        {
            _savingService = savingService;
        }

        private void Start()
        {
            bool haveSaves = _savingService.HaveAnySaves();
            gameObject.SetActive(haveSaves);
        }
    }
}