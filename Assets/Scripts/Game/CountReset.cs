using UnityEngine;

namespace UI.Game
{
    public class CountReset : MonoBehaviour
    {
        private GameOver gameOver;
        private PlayerController playerController;

        public void ResetDeadCount()
        {
            PlayerPrefs.DeleteKey(GameOver.DeadCountKey);
        }
        public void RestDistance()
        {
            PlayerPrefs.DeleteKey(PlayerController.LongestDistanceKey);
        }
    }
}