
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score; // переменная которая хранит счёт

    public void IncScore() // функция которая убет увеличивать наш счётчик на 1
    {
        score++;
        Debug.Log(score);
    }

    public void GameOver() // функция окончания игры
    {
        Debug.Log("Game Over");
    }

}
