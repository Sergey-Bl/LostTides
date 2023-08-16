using DefaultNamespace;
using TMPro;
using UI.Player;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject restartPopUp;
    [SerializeField] private TextMeshProUGUI _deadCountField;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UpdateDisplayDistance updateDisplayDistance;
    [SerializeField] private DistanceLoader distanceLoader;

    private int deadCount;
    internal const string DeadCountKey = "DeadCount";

    private void Start()
    {
        LoadDeadCount();
        UpdateDeadCountDisplay();
    }

    public void GameOverInit()
    {
        restartPopUp.SetActive(true);
        Time.timeScale = 0f;

        deadCount++;
        UpdateDeadCountDisplay();
        SaveDeadCount();
        distanceLoader.SaveLongestDistance();

        AppMetrica.Instance.ReportEvent("gameOver");

        AudioPlay audioPlay = GetComponent<AudioPlay>();
        audioPlay.musicStop();
        audioPlay.gameOverSound();
    }

    internal void UpdateDeadCountDisplay()
    {
        _deadCountField.text = ($"x" + deadCount);
    }

    public void HandleGameOver()
    {
        if (playerController.distanceTraveled > distanceLoader.longestDistance)
        {
            distanceLoader.longestDistance = playerController.distanceTraveled;
            distanceLoader.SaveLongestDistance();
        }

        updateDisplayDistance.UpdateDistanceDisplay();

        GameOverInit();
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