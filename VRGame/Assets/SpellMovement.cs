using UnityEngine;

public class SpellMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // Скорость движения заклинания
    [SerializeField] private float lifeTime = 5f;   // Время жизни заклинания (в секундах)

    private Vector3 moveDirection;                 // Направление движения заклинания
    private Rigidbody rb;                          // Rigidbody заклинания

    private void Start()
    {
        // Получаем Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody не найден на объекте заклинания!");
        }

        // Уничтожаем заклинание через заданное время
        //Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        // Двигаем заклинание, если Rigidbody существует
        if (rb != null)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    // Установить направление движения
    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized; // Нормализуем направление
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Заклинание столкнулось с врагом: {collision.gameObject.name}");
            Destroy(gameObject); // Уничтожаем заклинание при столкновении с врагом

        }
        else
        {
            Debug.Log($"Столкновение заклинания с объектом {collision.gameObject.name} проигнорировано.");
        }
    }
}
