using UnityEngine;

public class WinLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject winPopUp;

    [SerializeField]
    private AbstractMetrics metrics;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Win")) return;

        metrics.Send("WinLevel1");

        HandleWin();
    }

    private void HandleWin()
    {
        winPopUp.SetActive(true);

        LevelProgress.SetLevel1Passed(true);
    }
}