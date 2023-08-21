using TMPro;
using UnityEngine;

public class UpdateDisplayDistance : MonoBehaviour

{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private DistanceLoader _distanceLoader;

    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _distanceTextAfterLoose;
    [SerializeField] private TextMeshProUGUI _longestDistanceText;

    public void UpdateDistanceDisplay()
    {
        _distanceText.text = $"{_playerController.distanceTraveled:#.#}";
        _longestDistanceText.text = $"Best {_distanceLoader.longestDistance:#}m";
    }

    public void UpdateDistanceWhenLose()
    {
        _distanceTextAfterLoose.text = $"current result: {_playerController.distanceTraveled:#}m";
    }
}