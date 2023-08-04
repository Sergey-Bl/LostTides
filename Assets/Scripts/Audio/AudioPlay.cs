using UnityEngine;

namespace DefaultNamespace
{
    public class AudioPlay : MonoBehaviour
    {
        // [SerializeField] private AudioClip hurtSound;
        [SerializeField] private AudioSource soundSource;
        private void Start()
        {
            soundSource.Play();
        }
    }
}