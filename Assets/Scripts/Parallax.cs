using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Parallax : MonoBehaviour
{
  private MeshRenderer meshRenderer; // это компонент который является типом для отображения 3D обьектов, который позволяет отрисовать модели, текстуры и материалы
    public float animationSpeed = 0.1f;

    private void Awake()
    {
       
        meshRenderer = GetComponent<MeshRenderer>(); // Значение, полученное с помощью GetComponent,
                                                     // присваивается переменной meshRenderer, которая была объявлена ранее.
                                                     // Это позволяет вашему скрипту сохранить ссылку на компонент MeshRenderer,
                                                     // чтобы в дальнейшем использовать его для управления отображением 3D-графики этого объекта.
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2 (animationSpeed * Time.deltaTime, 0); //  применяет смещение текстуры объекта вдоль горизонтальной оси (X) - animationSpeed * Time.deltaTime
                                                                                                     // (Y) - 0
                                                                                                     //  на основе значения animationSpeed, что может использоваться
                                                                                                     //  для создания анимации движения текстуры на поверхности объекта.
    }

}


