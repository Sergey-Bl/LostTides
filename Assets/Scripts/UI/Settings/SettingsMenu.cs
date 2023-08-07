using UnityEngine;
using UnityEngine.Audio;

namespace UI.Settings
{
    public class SettingsMenu : MonoBehaviour
    {
       [SerializeField] private AudioMixer audioMixer;
        

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }
    }
}