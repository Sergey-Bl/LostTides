using UnityEngine;

public class GdprMenu : MonoBehaviour
{
    private string policyKey = "policy"; // Ключ для хранения состояния соглашения о политике.

    [SerializeField]
    private AbstractMetrics _metrics; // Ссылка на компонент метрик.

    private void Start()
    {
        var accepted = PlayerPrefs.GetInt(policyKey, 0) == 1; // Проверяем, было ли соглашение принято ранее.
        if (accepted)
            return;

        // Показываем диалоговое окно для соглашения о политике GDPR.
        SimpleGDPR.ShowDialog(
            new TermsOfServiceDialog().SetTermsOfServiceLink("https://sergey-bl.github.io/Terms-and-Conditions/")
                .SetPrivacyPolicyLink("https://sergey-bl.github.io/privacy-policy/"),
            OnMenuClosed);
    }

    private void OnMenuClosed()
    {
        Debug.LogWarning("Policy Accepted"); // Выводим сообщение о принятии соглашения в лог.
        _metrics.Send("gdprAccepted"); // Отправляем событие о принятии соглашения метрикам.
        PlayerPrefs.SetInt(policyKey, 1); // Устанавливаем флаг принятия соглашения.
    }
}