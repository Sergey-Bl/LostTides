using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI recordText;

    public void DisplayRecords()
    {
        float recordDistance = PlayerController.longestDistance;
        string recordsString = $"Longest Distance: {recordDistance:F2}";

        recordText.text = recordsString;
    }
}