using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    public Sprite[] sprites; // ������� ������ ��� �������� ���� �������� ������
    private int spriteIndex; // ���������� ��� �������� ������� �������

    private Vector3 direction; // 

    public float gravity = -9.81f; // ������������� ���������� ��� ���������, ��� �������� ��������� ���������� � �����

    public float strength = 5f; // ���� ������ �����

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>(); // �������� ������ �� ��������� SpriteRenderer, �� ���� ��� � ����� ����������, � ������ ������ Player
    }

    private void Start() // ����� ������� ��� ������ ������� ���� ����� ���������� ������ Awake()
    {
        //Application.targetFrameRate = 60;
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // ��������� ����� ������ ��� ������������ �������� ����� 15�� � ������ 15��
    }

    /*1. private void OnEnable(): ��� Unity-���������� �����, ������� ����������, ����� ������ ���������� ��������
    2. Vector3 position = transform.position - � ���� ������ ���� ���������� position ������������� ������� ��������� �������, 
    �� ������� ��������� ������ ������.transform - ��� ������ �� ��������� Transform ����� �������, 
    ������� �������� ���������� � ��� ���������, �������� � ��������.
    3. position.y = 0;: ����� �� ������������� ���������� y ������� ������ ����
    4. transform.position = position;: ����� �� ������������� ����� ��������� �������, 
    �������� ���������� �������� position.������ ������ ��������� �� ������ y = 0.
    5. direction = Vector3.zero;: ��� ������ ���� ������������� ���������� direction ������ �������� ������� Vector3.zero.*/
    private void OnEnable() 
    {
        Vector3 position = transform.position; 
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            direction = Vector3.up * strength; // ���������� �� ��� y
        }

        if(Input.touchCount > 0) // ���� ������� �� ������ ������ ��� 0
        {
            Touch touch = Input.GetTouch(0); // ��������, ��� �� ��������� ���������� � ������� ������� (touch event) �� ������ � ���������� ��� ���������� � ���������� touch.

            if (touch.phase == TouchPhase.Began) // ���� �������� ��������, �� ������� �������� ����
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime; // ���������� ��������� �� �����, � ������ ������ ����� ������������� �������� 

        transform.position += direction * Time.deltaTime; // ������ ������� ����� ����� ��������� ���� ��� ����� ����������
    }

    private void AnimateSprite() // ������� ������� ����������� �������� ������� ������� �� +1
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length) // ���� ������ ������� ������ ��� ����� ������ �������, ������� ������ �������� ������� �� 0. ��� ������� ��� ����, ����� ������ ��������� ��������
        {
            spriteIndex = 0;
        }

        spriteRender.sprite = sprites[spriteIndex]; // ����������� ������� �� �������

    }

    /*
    1.OnTriggerEnter2D - ������������ ��� ����������� ������������ �������� � ����������(2D) ������������
    2. (Collider2D other) - ��� ������ ���������� ������.� ������ ������, ����� ��������� ���� �������� - Collider2D, 
      ������� ���������� other.���� �������� ������������ ����� ��������� ������� �������, � ������� ��������� ������������
    3. other - �������� ������ ����, �� ������� �� ������� �������
     
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle") // ���� ������ ��� == Obstacle
        {
          
            FindObjectOfType<GameManager>().GameOver(); // �� ������ �������� GameOver

        } else if(other.gameObject.tag == "Scoring") // ���� ������ ��� == Scoring
        {
            FindObjectOfType<GameManager>().IncScore(); // �� ������ ������� IncScore - ������� �����
          
        }
    }

}
