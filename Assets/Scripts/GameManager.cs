
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player; // �������� ������ ������, �� ��� ����� ���������� � Unity �������

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public GameObject getReady;

   
    private int score; // ���������� ������� ������ ����

    private void Awake()
    {
        Application.targetFrameRate = 60; // ������������ ������� ������ 60
        Pause(); // ����� ��������� ����, �� ��� �� �����
        gameOver.SetActive(false); // �������� ���� ��������� �� �������
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

        Time.timeScale = 1f; // ������� �����
        player.enabled = true; // ����� �������? ��

        Pipes[] pipes = FindObjectsOfType<Pipes>(); // ����� ��� ��� ��������� ����, ��� ����� �������� ������ � ������� ���� � ���������� ��

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject); // ��� �����, ����� ��������� gameobject


        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; // ����� �� ����
        player.enabled = false; // ��������� ������ ������

    }

   

    public void GameOver() // ������� ��������� ����
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncScore() // ������� ������� ���� ����������� ��� ������� �� 1
    {
        score++; // ����������� ������� ����� �� 1

        scoreText.text = score.ToString(); // � ������ ����� ��������� ����

    }

}
