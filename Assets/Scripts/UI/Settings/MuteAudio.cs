using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    private const string MuteKey = "Muted"; // Ключ для сохранения информации о звуке в PlayerPrefs.

    public Toggle muteToggle; // Ссылка на компонент Toggle, представляющий переключатель включения/отключения звука.

    private void Start()
    {
        // Загружаем состояние звука из PlayerPrefs и устанавливаем его на Toggle.
        bool muted = PlayerPrefs.GetInt(MuteKey, 0) == 1;
        muteToggle.isOn = muted;

        // Применяем текущее состояние звука.
        SetMuted(muted);
    }

    public void MuteToggle(bool muted)
    {
        // При переключении звука вызываем метод SetMuted для применения изменений.
        SetMuted(muted);

        // Сохраняем состояние звука в PlayerPrefs.
        PlayerPrefs.SetInt(MuteKey, muted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SetMuted(bool muted)
    {
        // Устанавливаем громкость звука в зависимости от состояния.
        if (muted)
        {
            AudioListener.volume = 0; // Звук отключен.
        }
        else
        {
            AudioListener.volume = 1; // Звук включен.
        }
    }
}