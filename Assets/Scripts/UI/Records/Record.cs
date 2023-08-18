using TMPro;
using UI.Player;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;
    [SerializeField] private DistanceLoader distanceLoader;

    public void DisplayRecords()
    {
        distanceLoader.LoadLongestDistance();
        float recordDistance = distanceLoader.longestDistance;
        string recordsString = $"YOUR RECORD: {recordDistance:F2}";

        _recordText.text = recordsString;
    }

    public void Start()
    {
        DisplayRecords();
    }
}