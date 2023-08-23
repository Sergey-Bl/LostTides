using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _recordText;
    [SerializeField]
    private DistanceLoader _distanceLoader;

    public void DisplayRecords()
    {
        _distanceLoader.LoadLongestDistance();
        float recordDistance = _distanceLoader.longestDistance;
        string recordsString = $"YOUR RECORD: {recordDistance:#}m";

        _recordText.text = recordsString;
    }

    private void Start()
    {
        DisplayRecords();
    }
}