
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score; // ���������� ������� ������ ����

    public void IncScore() // ������� ������� ���� ����������� ��� ������� �� 1
    {
        score++;
        Debug.Log(score);
    }

    public void GameOver() // ������� ��������� ����
    {
        Debug.Log("Game Over");
    }

}
