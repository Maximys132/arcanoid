using UnityEngine;

public class Scr_PlayerMove : MonoBehaviour
{
    public float speed;
    public Joystick joystick;

    private Vector2 direction;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
        }
        else
        if (joystick.Horizontal != 0)
        {
            direction.x = joystick.Horizontal;
        }
        else direction.x = 0;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
