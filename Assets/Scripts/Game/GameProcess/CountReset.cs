using UnityEngine;

public class CountReset : MonoBehaviour
{
    private GameOver gameOver;
    [SerializeField]
    private AbstractMetrics metrics;

    public void ResetDeadCount()
    {
        metrics.Send("DeadCountResetTap");
        PlayerPrefs.DeleteKey(GameOver.DeadCountKey);
    }

    public void ResetDistance()
    {
        metrics.Send("DistanceCountResetTap");
        PlayerPrefs.DeleteKey(DistanceLoader.LongestDistanceKey);
    }
}