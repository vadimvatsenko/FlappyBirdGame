
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // ������� ������  prefab
    public float spawnRate = 1f;

    public float minHeight = -1f; // ����������� ������ �����
    public float maxHeight = 1f; // ������������ ������ �����

    private void OnEnable() // �������� ����������� ��� ��������� �������
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); // ��������� ����� ������� ����� 1���, ������ �������
    }

    private void OnDisable() // �������� ����������� ��� ����������� �������
    {
        CancelInvoke(nameof(Spawn)); // ���������� ������� Spawn
    }


    private void Spawn()
    {
        /*1.GameObject pipes - ��� ����������, � ������� ����� ��������� ������ �� ����� ��������� ������
        2.Instantiate - ��� ����� � Unity, ������� ��������� ������� ����� ������������� �������(���� ����� �������) � ���������� ��� �� �����.
        3.prefab - ��� ������ �� ������(������), ������� ����� �������������� � �������� ������ ��� �������� ������ �������. 
            ������� - ��� ������� ��������� ������� ��������, ������� ����� �������� ������������.
        4.transform.position - ��� �������, � ������� ����� �������� ����� ������
        5.Quaternion.identity - ��� ������ Quaternion, ������� ������������ ���������� ��������(��� ������� ��������)*/
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        /*������ ������ ���� ����������� ������� ������� ������� pipes � ����������� �����(�� ��� Y) 
        �� ��������� �������� � ��������� �� minHeight �� maxHeight.���, ��������, 
        ������������ ��� �������� ������� ���������� ������������� ���������� 
        ��������(��������, ��� �������� ��������� ������ ���� � ����).*/
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
}
