using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private 
        Transform player;
    [SerializeField] private 
        Vector3 offset;

    private void Update()
    {
        transform.position = player.position + offset;
    }
}