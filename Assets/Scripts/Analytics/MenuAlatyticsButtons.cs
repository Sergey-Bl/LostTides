using UnityEngine;

public class MenuAlatyticsButtons : MonoBehaviour
{
    public void PlayTap()
    {
        AppMetrica.Instance.ReportEvent("playButtonTapLevel1");
        Debug.Log("playButtonTapLevel1");
    }

    public void PlayTapLevel2()
    {
        AppMetrica.Instance.ReportEvent("playButtonTapLevel2");
        Debug.Log("playButtonTapLevel2");
    }

    public void SettingTap()
    {
        AppMetrica.Instance.ReportEvent("settingButtonTap");
        Debug.Log("settingButtonTap");
    }

    public void RecordTap()
    {
        AppMetrica.Instance.ReportEvent("recordButtonTap");
        Debug.Log("recordButtonTap");
    }

    public void StoreTap()
    {
        AppMetrica.Instance.ReportEvent("storeButtonTap");
        Debug.Log("storeButtonTap");
    }
}