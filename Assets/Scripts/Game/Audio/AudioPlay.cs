using UnityEngine;

// Класс для управления аудио в игре
//По мере добавление звуков класс будет раздуваться, лучше использовать звук в своём контексте
//Для общего менеджмента звуков можно использовать микшер
public class AudioPlay : MonoBehaviour
{
    // Звук для воспроизведения при завершении игры
    [SerializeField]
    private AudioSource _gameOver;

    // Звук фоновой музыки
    [SerializeField]
    private AudioSource _backSound;

    // Звук при сборе монеты или другого объекта
    [SerializeField]
    private AudioSource _collectCoin;

    // Остановка фоновой музыки
    //Для Методов стоит соблюдать PascalCase
    internal void musicStop()
    {
        _backSound.Stop();
    }

    // Воспроизведение звука при завершении игры
    internal void gameOverSound()
    {
        _gameOver.Play();
    }

    // Воспроизведение фоновой музыки
    internal void backGroundSound()
    {
        _backSound.Play();
    }

    // Воспроизведение звука при сборе монеты или другого объекта
    internal void collectSound()
    {
        _collectCoin.Play();
    }
}