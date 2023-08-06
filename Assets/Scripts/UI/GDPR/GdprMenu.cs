using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GdprMenu : MonoBehaviour
{
    private string policyKey = "policy";
    void Start()
    {
        var accepted = PlayerPrefs.GetInt(policyKey, 0) ==1;
        if(accepted)
            return;
        SimpleGDPR.ShowDialog(new TermsOfServiceDialog().SetTermsOfServiceLink("https://policies.google.com/terms?hl=en-US").SetPrivacyPolicyLink("https://www.google.com/gmail/about/policy/"),
            OnMenuClosed);
    }

    private void OnMenuClosed()
    {
        Debug.LogWarning("Policy Accepted");
        PlayerPrefs.SetInt(policyKey, 1);
    }
}