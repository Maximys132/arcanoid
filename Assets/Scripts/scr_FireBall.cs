using UnityEngine;

public class scr_FireBall : MonoBehaviour
{
    [SerializeField] private int _speed = 8;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * _speed;
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            DestroyObject(gameObject, 0.1f);
        }
    }

}
