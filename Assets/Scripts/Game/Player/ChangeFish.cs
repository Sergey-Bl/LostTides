using UnityEngine;

public class ChangeFish : MonoBehaviour
{
    public MeshFilter fishMeshFilter;

    /// <summary>
    /// Применяет новую сетку (меш) к рыбе.
    /// </summary>
    /// <param name="newMesh">Новая сетка рыбы.</param>
    public void ApplyNewFishMesh(Mesh newMesh)
    {
        // Проверяем, что сетка рыбы доступна.
        if (fishMeshFilter == null) return;

        // Присваиваем новую сетку рыбы.
        fishMeshFilter.mesh = newMesh;

        // Устанавливаем новый масштаб для рыбы.
        transform.localScale = new Vector3(0.5285938f, 0.7903844f, 2f);

        // Получаем компонент коллайдера типа "BoxCollider2D".
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        // Проверяем, что коллайдер доступен.
        if (boxCollider == null) return;

        // Устанавливаем новый размер и смещение коллайдера.
        boxCollider.size = new Vector2(1.01f, 0.43f);
        boxCollider.offset = new Vector2(-0.04f, 0f);
    }
}