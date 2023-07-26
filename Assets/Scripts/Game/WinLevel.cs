using UnityEngine;

public class WinLevel : MonoBehaviour
{
    
    [SerializeField]private GameObject WinPopUp;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Win"))
        {
            HandleWin();
        }
    }
    private void HandleWin()
    {
        Debug.Log("Win");
        WinPopUp.SetActive(true);
    }
}