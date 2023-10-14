using UnityEngine;
public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    public Sprite[] sprites; // создаем массив для хранения всех спрайтов птички
    private int spriteIndex; // переменная для хранения индекса спрайта

    private Vector3 direction; // 

    public float gravity = -9.81f; // устанавливаем гравитацию для персонажа, это значение настоящей гравитации в жизни

    public float strength = 5f; // сила взмаха птицы

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>(); // получаем ссылку на компонент SpriteRenderer, он ищет его в нашем компоненте, в данном случае Player
    }

    private void Start() // будет запущен при первом запуске игры после выполнения метода Awake()
    {
        //Application.targetFrameRate = 60;
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // повторный вызов метода для переключения спрайтов через 15мс и каждые 15мс
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            direction = Vector3.up * strength; // увеличение по оси y
        }

        if(Input.touchCount > 0) // если нажатий по экрану больше чем 0
        {
            Touch touch = Input.GetTouch(0); // означает, что вы получаете информацию о событии касания (touch event) на экране и сохраняете эту информацию в переменной touch.

            if (touch.phase == TouchPhase.Began) // есди кассание началось, то выполни действие ниже
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime; // гравитация умноженая на время, в данном случае будет отрицательное значение 

        transform.position += direction * Time.deltaTime; // теперь позиция птици будет сдвигатся вниз под силой гравитации
    }

    private void AnimateSprite() // функция которая увеличивает значение индекса спрайта на +1
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length) // если индекс спрайта больше или равно длинне спрайта, вернуть индекс значения спрайта на 0. Это сделано для того, чтобы заново запустить анимацию
        {
            spriteIndex = 0;
        }

        spriteRender.sprite = sprites[spriteIndex]; // переключает спрайты по очереди

    }

    /*
    1.OnTriggerEnter2D - используется для обнаружения столкновения объектов в двухмерном(2D) пространстве
    2. (Collider2D other) - это список параметров метода.В данном случае, метод принимает один параметр - Collider2D, 
      который называется other.Этот параметр представляет собой коллайдер другого объекта, с которым произошло столкновение
    3. other - означает другие теги, те которые мы создали вручную
     
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle") // если другой тег == Obstacle
        {
            FindObjectOfType<GameManager>().GameOver(); // то вызови функкцию GameOver
        } else if(other.gameObject.tag == "Scoring") // если другой тег == Scoring
        {
            FindObjectOfType<GameManager>().IncScore(); // то вызови функцию IncScore - подсчет очков
        }
    }

}
