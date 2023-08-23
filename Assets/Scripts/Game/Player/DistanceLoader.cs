using UnityEngine;

public class DistanceLoader : MonoBehaviour
{
    public float longestDistance;
    internal const string LongestDistanceKey = "LongestDistance";

    /// <summary>
    /// Сохраняет самое длинное пройденное расстояние.
    /// </summary>
    public void SaveLongestDistance()
    {
        PlayerPrefs.SetFloat(LongestDistanceKey, longestDistance);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Загружает самое длинное пройденное расстояние.
    /// </summary>
    public void LoadLongestDistance()
    {
        //можно сделать в одну строчку 
        longestDistance = PlayerPrefs.GetFloat(LongestDistanceKey, 0);
        // if (PlayerPrefs.HasKey(LongestDistanceKey))
        // {
        //     longestDistance = PlayerPrefs.GetFloat(LongestDistanceKey);
        // }
        // else
        // {
        //     longestDistance = 0f;
        // }
        
    }
}