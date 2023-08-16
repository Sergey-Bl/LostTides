using UI.Player;
using UnityEngine;

namespace UI.Game
{
    public class CountReset : MonoBehaviour
    {
        private GameOver gameOver;
        private DistanceLoader distanceLoader;

        public void ResetDeadCount()
        {
            PlayerPrefs.DeleteKey(GameOver.DeadCountKey);
        }

        public void RestDistance()
        {
            PlayerPrefs.DeleteKey(DistanceLoader.LongestDistanceKey);
        }
    }
}