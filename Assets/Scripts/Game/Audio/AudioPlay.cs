using UnityEngine;

namespace DefaultNamespace
{
    public class AudioPlay : MonoBehaviour
    {
        [SerializeField] private AudioSource gameOver;
        [SerializeField] private AudioSource backSound;
        [SerializeField] private AudioSource collectCoin;
        [SerializeField] private AudioSource tap;

        internal void musicStop()
        {
            backSound.Stop();
        }

        internal void gameOverSound()
        {
            gameOver.Play();
        }

        internal void backGroundSound()
        {
            backSound.Play();
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