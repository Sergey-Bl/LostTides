using UnityEngine;
using UnityEngine.Audio;

namespace UI.Settings
{
    public class SettingsMenu : MonoBehaviour
    {
       [SerializeField] 
       private AudioMixer _audioMixer;
        

        public void SetVolume(float volume)
        {
            _audioMixer.SetFloat("volume", volume);
        }
    }
}