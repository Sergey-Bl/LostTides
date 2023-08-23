using UnityEngine;

public class SaveCountDead : MonoBehaviour
{
    [SerializeField]
    private GameOver _gameOver;

    internal void SaveDeadCount()
    {
        PlayerPrefs.SetInt(GameOver.DeadCountKey, _gameOver.deadCount);
        PlayerPrefs.Save();
    }

    internal void LoadDeadCount()
    {
        _gameOver.deadCount = PlayerPrefs.HasKey(GameOver.DeadCountKey) ? PlayerPrefs.GetInt(GameOver.DeadCountKey) : 0;
    }
}