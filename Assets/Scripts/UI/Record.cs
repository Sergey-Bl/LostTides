using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    private PlayerController playerController;
    
    [SerializeField] private TextMeshProUGUI recordText;

    public void Start()
    {
        DisplayRecords();
    }

    public void DisplayRecords()
    {
        float recordDistance = PlayerController.longestDistance;
        string recordsString = $"Longest Distance: {recordDistance:F2}";

        recordText.text = recordsString;
    }
}