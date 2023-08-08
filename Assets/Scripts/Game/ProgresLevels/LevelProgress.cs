using UnityEngine;

public static class LevelProgress
{
    private const string Level1Key = "Level1Passed";

    public static bool IsLevel1Passed()
    {
        return PlayerPrefs.GetInt(Level1Key, 0) == 1;
    }

    public static void SetLevel1Passed(bool passed)
    {
        PlayerPrefs.SetInt(Level1Key, passed ? 1 : 0);
        PlayerPrefs.Save();
    }
}