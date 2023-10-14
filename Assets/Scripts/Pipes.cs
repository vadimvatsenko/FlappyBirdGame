using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{

    public float speed = 5f; // устанавливаем скорость наший труб

    public float leftEdge; // переменная которая хранить в себе левый край нашего экрана



    private void Start()
    {
       /*1.Camera.main - это статическое свойство в Unity, которое предоставляет ссылку на основную камеру в сцене
        2.ScreenToWorldPoint - Этот метод используется для преобразования точки из координат экрана в координаты видимой области(вьюпорта)
        3.Vector3.zero - представляет точку с координатами(0, 0, 0)
        4. - 1f - Это значит, что из значения X координаты в видимой области вычитается 1, чтобы получить значение, которое соответствует левой границе видимой области экрана*/
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // трансформируем наши трубы в лево умножая положение влево на скорость и время
        

        if(transform.position.x < leftEdge) // если позиция нашей трубы по х меньше левого края нашой сцены
        {
            Destroy(gameObject); // то удалить обьект, тоесть трубу

        }
    }
}



