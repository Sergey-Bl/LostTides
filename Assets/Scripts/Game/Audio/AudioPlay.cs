using UnityEngine;

namespace DefaultNamespace
{
    public class AudioPlay : MonoBehaviour
    {
        [SerializeField] private AudioSource gameOver;
        [SerializeField] private AudioSource soundSource;
        [SerializeField] private AudioSource collectCoin;
        [SerializeField] private AudioSource tap;

        private void Start()
        {
            soundSource.Play();
        }

        internal void musicStop()
        {
            soundSource.Stop();
        }

        internal void gameOverSound()
        {
            gameOver.Play();
        }

        internal void collectSound()
        {
            collectCoin.Play();
        }
        
        internal void tapSound()
        {
            tap.Play();
        }
    }
}