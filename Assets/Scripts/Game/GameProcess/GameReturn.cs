using UnityEngine;

public class GameReturn : MonoBehaviour
{
    /// <summary>
    /// Восстановление времени в игре, чтобы вернуться к нормальному проигрыванию.
    /// </summary>
    public void GameReturns()
    {
        Time.timeScale = 1f;  // Установка времени в 1, чтобы игра продолжилась в обычном режиме.
    }
}