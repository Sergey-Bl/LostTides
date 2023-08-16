using UnityEngine;

namespace UI.Player
{
    public class DistanceLoader : MonoBehaviour
    {
        public float longestDistance { get; set; } = 0f;
        internal const string LongestDistanceKey = "LongestDistance";
        
        public void SaveLongestDistance()
        {
            PlayerPrefs.SetFloat(LongestDistanceKey, longestDistance);
            PlayerPrefs.Save();
        }

        public void LoadLongestDistance()
        {
            if (PlayerPrefs.HasKey(LongestDistanceKey))
            {
                longestDistance = PlayerPrefs.GetFloat(LongestDistanceKey);
            }
            else
            {
                longestDistance = 0f;
            }
        }
    }
}