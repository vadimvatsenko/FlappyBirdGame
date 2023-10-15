
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player; // получаем обьект игрока, но его нужно перетянуть в Unity вручную

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public GameObject getReady;

   
    private int score; // переменная которая хранит счёт

    private void Awake()
    {
        Application.targetFrameRate = 60; // устанавливаю частоту кадров 60
        Pause(); // когда запускаем игру, то она на паузе
        gameOver.SetActive(false); // Картинка Игра закончена не активна
        getReady.SetActive(true);
        playButton.SetActive(true);

        
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);

        Time.timeScale = 1f; // обычное время
        player.enabled = true; // игрок активен? да

        Pipes[] pipes = FindObjectsOfType<Pipes>(); // перед тем как запустить игру, нам нужно получить доступ в массиву труб и уничтожить их

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject); // тут важно, нужно добавлять gameobject


        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; // время на нуле
        player.enabled = false; // отключает игрока птичку

    }

   

    public void GameOver() // функция окончания игры
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncScore() // функция которая убет увеличивать наш счётчик на 1
    {
        score++; // увеличиваем счётчик очком на 1

        scoreText.text = score.ToString(); // в обьект теста вставляем счёт

    }

}
