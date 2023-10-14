
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // создаем обьект  prefab
    public float spawnRate = 1f;

    public float minHeight = -1f; // минимальная высота трубы
    public float maxHeight = 1f; // максимальная высота трубы

    private void OnEnable() // действие выполняется при активации скрипта
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); // повторять вызов функции через 1сек, каждую секунду
    }

    private void OnDisable() // действие прекратится при деактивации скрипта
    {
        CancelInvoke(nameof(Spawn)); // остановить функции Spawn
    }


    private void Spawn()
    {
        /*1.GameObject pipes - Это переменная, в которой будет сохранена ссылка на новый созданный объект
        2.Instantiate - это метод в Unity, который позволяет создать копию существующего объекта(чаще всего префаба) и разместить его на сцене.
        3.prefab - Это ссылка на объект(префаб), который будет использоваться в качестве основы для создания нового объекта. 
            Префабы - это заранее созданные шаблоны объектов, которые можно повторно использовать.
        4.transform.position - Это позиция, в которой будет размещен новый объект
        5.Quaternion.identity - Это объект Quaternion, который представляет отсутствие вращения(или нулевое вращение)*/
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        /*данная строка кода увеличивает текущую позицию объекта pipes в направлении вверх(по оси Y) 
        на случайное значение в диапазоне от minHeight до maxHeight.Это, вероятно, 
        используется для создания эффекта случайного вертикального размещения 
        объектов(например, для создания случайной высоты труб в игре).*/
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
}
