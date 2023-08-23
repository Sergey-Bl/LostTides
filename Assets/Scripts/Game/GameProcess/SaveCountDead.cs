using UnityEngine;

//Идентично с SaveCoinsPlef
public class SaveCountDead : MonoBehaviour
{
    [SerializeField]
    private GameOver _gameOver;

    /// <summary>
    /// Сохраняет количество смертей в PlayerPrefs.
    /// </summary>
    internal void SaveDeadCount()
    {
        PlayerPrefs.SetInt(GameOver.DeadCountKey, _gameOver.deadCount);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Загружает количество смертей из PlayerPrefs.
    /// </summary>
    internal void LoadDeadCount()
    {
        if (PlayerPrefs.HasKey(GameOver.DeadCountKey))
        {
            _gameOver.deadCount = PlayerPrefs.GetInt(GameOver.DeadCountKey);
        }
        else
        {
            _gameOver.deadCount = 0;
        }
    }
}