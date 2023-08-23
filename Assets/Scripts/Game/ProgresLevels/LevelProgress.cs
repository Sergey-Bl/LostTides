using UnityEngine;

public static class LevelProgress
{
    private const string Level1Key = "Level1Passed";

    // Проверяет, был ли первый уровень пройден.
    public static bool IsLevel1Passed()
    {
        return PlayerPrefs.GetInt(Level1Key, 0) == 1;
    }

    // Устанавливает состояние пройденности первого уровня.
    //Где второй уровень? Слишком большая привязка на количество уровней, плюс статика, не переиспользуемо
    public static void SetLevel1Passed(bool passed)
    {
        PlayerPrefs.SetInt(Level1Key, passed ? 1 : 0);
        PlayerPrefs.Save();
    }
}