using UnityEngine;

public class GdprMenu : MonoBehaviour
{
    private string policyKey = "policy";

    private void Start()
    {
        var accepted = PlayerPrefs.GetInt(policyKey, 0) == 1;
        if (accepted)
            return;
        SimpleGDPR.ShowDialog(
            new TermsOfServiceDialog().SetTermsOfServiceLink("https://sergey-bl.github.io/Terms-and-Conditions/")
                .SetPrivacyPolicyLink("https://sergey-bl.github.io/privacy-policy/"),
            OnMenuClosed);
    }

    private void OnMenuClosed()
    {
        Debug.LogWarning("Policy Accepted");
        AppMetrica.Instance.ReportEvent("gdprAccepted");
        PlayerPrefs.SetInt(policyKey, 1);
    }
}