using TMPro;
using UI.Game;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _deadCountField;

    [SerializeField] 
    private GameObject restartPopUp;

    [SerializeField]
    private PlayerController _playerController;
    
    [SerializeField]
    private AbstractMetrics metrics;

    [SerializeField]
    private SaveCountDead _saveCountDead;

    [SerializeField]
    private UpdateDisplayDistance _updateDisplayDistance;

    [SerializeField]
    private DistanceLoader _distanceLoader;

    internal const string DeadCountKey = "DeadCount";
    public int deadCount;


    private void Start()
    {
        _saveCountDead.LoadDeadCount();
        UpdateDeadCountDisplay();
    }

    public void GameOverInit()
    {
        restartPopUp.SetActive(true);

        deadCount++;
        UpdateDeadCountDisplay();
        _saveCountDead.SaveDeadCount();
        _distanceLoader.SaveLongestDistance();

        metrics.Send("gameOver");

        AudioPlay audioPlay = GetComponent<AudioPlay>();
        audioPlay.musicStop();
        audioPlay.gameOverSound();

        Time.timeScale = 0f;
    }

    internal void UpdateDeadCountDisplay()
    {
        _deadCountField.text = ($"x" + deadCount);
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
}