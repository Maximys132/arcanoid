
using UnityEngine;

public class scr_FireBall : MonoBehaviour
{
    [SerializeField] public Transform _startPos;
    [SerializeField] private int _speed = 8;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().position = _startPos.position;
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
