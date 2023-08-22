using UnityEngine;

// Класс для следования камеры за объектом (игроком)
public class CameraFollow : MonoBehaviour
{
    // Ссылка на трансформ игрока, за которым будет следовать камера
    [SerializeField] private Transform player;

    // Смещение камеры относительно игрока
    [SerializeField] private Vector3 offset;

    // Обновление позиции камеры
    private void Update()
    {
        // Установка позиции камеры равной позиции игрока плюс смещение
        transform.position = player.position + offset;
    }
}