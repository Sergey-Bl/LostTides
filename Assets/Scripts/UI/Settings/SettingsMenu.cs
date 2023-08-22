using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer; // Ссылка на аудио-микшер, управляющий звуковыми параметрами.

    public void SetVolume(float volume)
    {
        // Метод устанавливает уровень громкости в аудио-микшере по имени параметра "volume".
        // Переданный аргумент "volume" будет использован для установки нового значения громкости.
        _audioMixer.SetFloat("volume", volume);
    }
}