using UnityEngine;

public class scr_FireBall : MonoBehaviour
{
    [SerializeField] private int _speed = 20;
    [SerializeField] private int _health  = 0;


    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * _speed;
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D collision)
    {// 
        if (_health > 0 && collision.CompareTag("Brick"))
        {
            Debug.Log("Laser on brick");
            gameObject.active = false;
            DestroyObject(gameObject, 0f);
        }
        if (collision.CompareTag("Respawn"))
        {
            DestroyObject(gameObject, 0.1f);
        }
    }

}
