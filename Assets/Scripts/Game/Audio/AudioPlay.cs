using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private
        AudioSource _gameOver;
    [SerializeField] private
        AudioSource _backSound;
    [SerializeField] private
        AudioSource _collectCoin;
    [SerializeField] private
        AudioSource _tapPlayer;

    internal void musicStop()
    {
        _backSound.Stop();
    }

    internal void gameOverSound()
    {
        _gameOver.Play();
    }

    internal void backGroundSound()
    {
        _backSound.Play();
    }

    internal void collectSound()
    {
        _collectCoin.Play();
    }

    internal void tapPlayer()
    {
        _tapPlayer.Play();
    }
}