using UnityEngine;

public class MenuAlatyticsButtons : MonoBehaviour
{
    [SerializeField] private AbstractMetrics metrics;
    public void PlayTap()
    {
        metrics.Send("playButtonTapLevel1");
    }

    public void PlayTapLevel2()
    {
        metrics.Send("playButtonTapLevel2");
    }

    public void SettingTap()
    {
        metrics.Send("settingButtonTap");
    }

    public void StoreTap()
    {
        metrics.Send("storeButtonTap");
    }
}