using UnityEngine;

public class GdprMenu : MonoBehaviour
{
    private string policyKey = "policy";

    void Start()
    {
        var accepted = PlayerPrefs.GetInt(policyKey, 0) == 1;
        if (accepted)
            return;
        SimpleGDPR.ShowDialog(
            new TermsOfServiceDialog().SetTermsOfServiceLink("https://www.freeprivacypolicy.com/live/627e5bcc-8f1e-4340-bd30-a17be03b1955")
                .SetPrivacyPolicyLink("https://www.freeprivacypolicy.com/live/0ae4936f-b632-4a2b-88f7-a20a9d02b4e5"),
            OnMenuClosed);
    }

    private void OnMenuClosed()
    {
        Debug.LogWarning("Policy Accepted");
        AppMetrica.Instance.ReportEvent("gdprAccepted");
        PlayerPrefs.SetInt(policyKey, 1);
    }
}