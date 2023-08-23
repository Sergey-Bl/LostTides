using Metrics;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private
        TextMeshProUGUI _deadCountField;
    [SerializeField] private
        GameObject restartPopUp;
    [SerializeField] private
        PlayerController _playerController;
    [SerializeField] private
        AnalyticsKeys _analyticsKeys;
    [SerializeField] private
        UpdateDisplayDistance _updateDisplayDistance;
    [SerializeField] private
        DistanceLoader _distanceLoader;

    internal const string DeadCountKey = "DeadCount";
    public int deadCount { get; private set; }

    private void Start()
    {
        LoadDeadCount();
        UpdateDeadCountDisplay();
    }

    public void GameOverInit()
    {
        restartPopUp.SetActive(true);

        deadCount++;
        UpdateDeadCountDisplay();
        SaveDeadCount();

        _distanceLoader.SaveLongestDistance();

        _analyticsKeys.GameOverAnalytic();

        AudioPlay audioPlay = GetComponent<AudioPlay>();
        audioPlay.musicStop();
        audioPlay.gameOverSound();

        Time.timeScale = 0f;
    }

    internal void UpdateDeadCountDisplay()
    {
        _deadCountField.text = $"x{deadCount}";
    }

    public void HandleGameOver()
    {
        if (_playerController.distanceTraveled > _distanceLoader.longestDistance)
        {
            _distanceLoader.longestDistance = _playerController.distanceTraveled;
            _distanceLoader.SaveLongestDistance();
        }

        _updateDisplayDistance.UpdateDistanceDisplay();
        _updateDisplayDistance.UpdateDistanceWhenLose();

        GameOverInit();
    }

    internal void SaveDeadCount()
    {
        PlayerPrefs.SetInt(DeadCountKey, deadCount);
        PlayerPrefs.Save();
    }

    internal void LoadDeadCount()
    {
        deadCount = PlayerPrefs.HasKey(DeadCountKey) ? PlayerPrefs.GetInt(DeadCountKey) : 0;
    }
}