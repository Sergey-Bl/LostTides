using TMPro;
using UI.Player;
using UnityEngine;

public class UpdateDisplayDistance : MonoBehaviour

{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private DistanceLoader distanceLoader;

    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI longestDistanceText;

    public void UpdateDistanceDisplay()
    {
        distanceText.text = $"{playerController.distanceTraveled:#.#}";
        longestDistanceText.text = $"Best {distanceLoader.longestDistance:#.#}";
    }
}