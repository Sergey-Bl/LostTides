using UnityEngine;

namespace UI.Game
{
    public class SaveCountDead : MonoBehaviour
    {
        [SerializeField]
        private GameOver _gameOver;

        internal void SaveDeadCount()
        {
            PlayerPrefs.SetInt(GameOver.DeadCountKey, _gameOver.deadCount);
            PlayerPrefs.Save();
        }

        internal void LoadDeadCount()
        {
            if (PlayerPrefs.HasKey(GameOver.DeadCountKey))
            {
                _gameOver.deadCount = PlayerPrefs.GetInt(GameOver.DeadCountKey);
            }
            else
            {
                _gameOver.deadCount = 0;
            }
        }
    }
}