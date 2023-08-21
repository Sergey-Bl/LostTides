using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] 
    private GameObject Level2Button;

    private void Start()
    {
        if (LevelProgress.IsLevel1Passed())
        {
            Level2Button.SetActive(true);
        }
    }
}