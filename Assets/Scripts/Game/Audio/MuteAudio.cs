using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MuteAudio : MonoBehaviour
    {
        private const string MuteKey = "Muted"; // Key for PlayerPrefs

        public Toggle muteToggle; // Reference to the Toggle UI element

        private void Start()
        {
            bool muted = PlayerPrefs.GetInt(MuteKey, 0) == 1;

            // Set the Toggle's value based on the muted state
            muteToggle.isOn = muted;

            SetMuted(muted);
        }

        public void MuteToggle(bool muted)
        {
            SetMuted(muted);

            PlayerPrefs.SetInt(MuteKey, muted ? 1 : 0);
            PlayerPrefs.Save();
        }

        private void SetMuted(bool muted)
        {
            if (muted)
            {
                AudioListener.volume = 0;
            }
            else
            {
                AudioListener.volume = 1;
            }
        }
    }
}