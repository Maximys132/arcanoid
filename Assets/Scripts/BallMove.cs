using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed = 8;
    public GameObject platform;
    public GameObject level;

    private Rigidbody2D rg;
    //private float maxAngleInterval = 0.67f;
    private Rigidbody2D rbPlatform;
    private bool isStarted;
    private LevelsRule lvlRule;

    // Start is called before the first frame update
    void Start()
    {
        rbPlatform = platform.GetComponent<Rigidbody2D>();
        rg = GetComponent<Rigidbody2D>();
        lvlRule = level.GetComponent<LevelsRule>();
        isStarted = true;
        /*Vector2 dir = Vector2.up;
        dir.x = UnityEngine.Random.Range(-maxAngleInterval, maxAngleInterval);
        rg.velocity = dir * speed;*/
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            lvlRule.BallFall();
            //UnityEngine.Debug.Log("ladida");
            isStarted = true;
        }
        if (collision.CompareTag("Player"))
        {
            //UnityEngine.Debug.Log("Puk " + newVelosity);
            Vector2 newVelosity = (rg.position - Vector2.down) - collision.attachedRigidbody.position;
            rg.velocity = newVelosity.normalized * speed;
        }
    }
    void Update()
    {
        if (Input.GetAxisRaw("Jump") > 0.01f)
        {
            isStarted = false;
        }
    }
    void FixedUpdate()
    {
        if (isStarted)
        {
            rg.position = rbPlatform.position + Vector2.up * 0.35f;
        }
    }
}
