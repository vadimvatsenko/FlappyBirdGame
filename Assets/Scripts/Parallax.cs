using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Parallax : MonoBehaviour
{
  private MeshRenderer meshRenderer; // ��� ��������� ������� �������� ����� ��� ����������� 3D ��������, ������� ��������� ���������� ������, �������� � ���������
    public float animationSpeed = 0.1f;

    private void Awake()
    {
       
        meshRenderer = GetComponent<MeshRenderer>(); // ��������, ���������� � ������� GetComponent,
                                                     // ������������� ���������� meshRenderer, ������� ���� ��������� �����.
                                                     // ��� ��������� ������ ������� ��������� ������ �� ��������� MeshRenderer,
                                                     // ����� � ���������� ������������ ��� ��� ���������� ������������ 3D-������� ����� �������.
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2 (animationSpeed * Time.deltaTime, 0); //  ��������� �������� �������� ������� ����� �������������� ��� (X) - animationSpeed * Time.deltaTime
                                                                                                     // (Y) - 0
                                                                                                     //  �� ������ �������� animationSpeed, ��� ����� ��������������
                                                                                                     //  ��� �������� �������� �������� �������� �� ����������� �������.
    }

}


