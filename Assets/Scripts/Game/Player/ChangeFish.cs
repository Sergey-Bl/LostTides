using UnityEngine;

public class ChangeFish : MonoBehaviour
{
    public SkinnedMeshRenderer fishSkinnedMeshRenderer;

    // [SerializeField] private Vector3 newFishScale = new Vector3(0.5285938f, 0.7903844f, 2f);
    [SerializeField] private float boxColliderWidth = 1.01f;
    [SerializeField] private float boxColliderHeight = 0.43f;
    [SerializeField] private float boxColliderOffsetX = -0.04f;
    [SerializeField] private float boxColliderOffsetY = 0f;

    public void ApplyNewFishMesh(Mesh newMesh)
    {
        if (fishSkinnedMeshRenderer == null) return;

        fishSkinnedMeshRenderer.sharedMesh = newMesh;
        

        // transform.localScale = newFishScale;

        // CapsuleCollider2D capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        //
        // if (capsuleCollider2D == null) return;
        //
        // capsuleCollider2D.size = new Vector2(boxColliderWidth, boxColliderHeight);
        // capsuleCollider2D.offset = new Vector2(boxColliderOffsetX, boxColliderOffsetY);
    }
    public void ApplyNewFishSkinnedMeshRenderer(SkinnedMeshRenderer newSkinnedMeshRenderer)
    {
        if (fishSkinnedMeshRenderer != null && newSkinnedMeshRenderer != null)
        {
            fishSkinnedMeshRenderer.sharedMesh = newSkinnedMeshRenderer.sharedMesh;
            fishSkinnedMeshRenderer.bones = newSkinnedMeshRenderer.bones;
            fishSkinnedMeshRenderer.rootBone = newSkinnedMeshRenderer.rootBone;
        }
    }
}