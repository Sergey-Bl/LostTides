using UnityEngine;

namespace UI.Player
{
    public class ChangeFish : MonoBehaviour
    {
        public MeshFilter fishMeshFilter;

        public void ApplyNewFishMesh(Mesh newMesh)
        {
            if (fishMeshFilter != null)
            {
                fishMeshFilter.mesh = newMesh;

                transform.localScale = new Vector3(0.5285938f, 0.7903844f, 2f);
                BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
                if (boxCollider != null)
                {
                    boxCollider.size = new Vector2(1.01f, 0.43f);
                    boxCollider.offset = new Vector2(-0.04f, 0f);
                }
            }
        }
    }
}