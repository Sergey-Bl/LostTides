using UnityEngine;

public class DistanceLoader : MonoBehaviour
{
    public float longestDistance;
    internal const string LongestDistanceKey = "LongestDistance";

    public void SaveLongestDistance()
    {
        PlayerPrefs.SetFloat(LongestDistanceKey, longestDistance);
        PlayerPrefs.Save();
    }

    public void LoadLongestDistance()
    {
        longestDistance = PlayerPrefs.HasKey(LongestDistanceKey) ? PlayerPrefs.GetFloat(LongestDistanceKey) : 0f;
    }
}