using Saving;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelService : ILevelService
    {
        private const string _gameName = "Game";

        public void LoadGame()
        {
            SceneManager.LoadScene(_gameName);
        }
    }
}
