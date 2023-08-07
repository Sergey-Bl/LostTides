using DefaultNamespace;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject restartPopUp;
    [SerializeField] private TextMeshProUGUI _deadCountField;
    
    private int deadCount;
    internal const string DeadCountKey  = "DeadCount";

    private void Start()
    {
        LoadDeadCount();
        UpdateDeadCountDisplay();
    }

    public void HandleGameOver()
    {
        Debug.Log("Game Over");
        restartPopUp.SetActive(true);
        Time.timeScale = 0f;

        deadCount++;
        UpdateDeadCountDisplay();
        SaveDeadCount();
        
        AudioPlay audioPlay = GetComponent<AudioPlay>();
        audioPlay.musicStop();
        audioPlay.gameOverSound();
    }

    internal void UpdateDeadCountDisplay()
    {
        _deadCountField.text = ($"x" + deadCount);
    }

    private void SaveDeadCount()
    {
        PlayerPrefs.SetInt(DeadCountKey, deadCount);
        PlayerPrefs.Save();
    }

    private void LoadDeadCount()
    {
        if (PlayerPrefs.HasKey(DeadCountKey))
        {
            deadCount = PlayerPrefs.GetInt(DeadCountKey);
        }
        else
        {
            deadCount = 0;
        }
    }
}