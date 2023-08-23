using UnityEngine;

public class ChangeFish : MonoBehaviour
{
    public MeshFilter fishMeshFilter;

    [SerializeField]
    private Vector3 newFishScale = new Vector3(0.5285938f, 0.7903844f, 2f);
    [SerializeField]
    private float boxColliderWidth = 1.01f;
    [SerializeField]
    private float boxColliderHeight = 0.43f;
    [SerializeField]
    private float boxColliderOffsetX = -0.04f;
    [SerializeField]
    private float boxColliderOffsetY = 0f;

    public void ApplyNewFishMesh(Mesh newMesh)
    {
        if (fishMeshFilter == null) return;

        fishMeshFilter.mesh = newMesh;

        transform.localScale = newFishScale;

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider == null) return;

        boxCollider.size = new Vector2(boxColliderWidth, boxColliderHeight);
        boxCollider.offset = new Vector2(boxColliderOffsetX, boxColliderOffsetY);
    }
}