using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    private const string MuteKey = "Muted";

    public Toggle muteToggle;

    private void Start()
    {
        bool muted = PlayerPrefs.GetInt(MuteKey, 0) == 1;

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