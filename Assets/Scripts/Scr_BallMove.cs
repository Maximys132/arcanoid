using UnityEngine;

public class Scr_BallMove : MonoBehaviour
{
    public float speed = 8;
    public GameObject platform;
    public GameObject level;
    public Joystick joystick;
    [SerializeField] private AudioClip[] clips;

    private Rigidbody2D rg;
    //private float maxAngleInterval = 0.67f;
    private Rigidbody2D rbPlatform;
    private bool isStarted;
    private Scr_LevelsRule lvlRule;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        rbPlatform = platform.GetComponent<Rigidbody2D>();
        rg = GetComponent<Rigidbody2D>();
        lvlRule = level.GetComponent<Scr_LevelsRule>();
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
        if (Input.GetAxisRaw("Jump") > 0.01f || joystick.Vertical > 0.7f)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!collision.gameObject.CompareTag("Player"))
        //{
            audioSrc.PlayOneShot(clips[UnityEngine.Random.Range(0, clips.Length)]);
        //}
    }
}
