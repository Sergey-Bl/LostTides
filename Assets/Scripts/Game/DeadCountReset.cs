using UnityEngine;

namespace UI.Game
{
    public class DeadCountReset : MonoBehaviour
    {
        private GameOver gameOver;

        public void ResetDeadCount()
        {
            PlayerPrefs.DeleteKey(GameOver.DeadCountKey);
        }
    }
}