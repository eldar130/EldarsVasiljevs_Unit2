using UnityEngine;

public class fly_script : MonoBehaviour
{
    [SerializeField] private float velocity = 2f;
    [SerializeField] private float rotationSpeed = 10f;
    AudioManager audioManager;
    private Rigidbody2D rb;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only allow flapping if the game is active
        if (!game_manager_script.instance.isGameActive)
            return;

        //go up when mouse or space bar pressed
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            audioManager.PlaySFX(audioManager.flap);
            rb.linearVelocity = Vector2.up * velocity;
        }
    }

    //bird rotation
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocityY * rotationSpeed);
    }

    // colission check
    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "floor":
                audioManager.PlaySFX(audioManager.hitFloor);
                GameOver();
                break;

            case "pipes":
                audioManager.PlaySFX(audioManager.hitPipe);
                GameOver();
                break;
        }
    }

    private void GameOver()
    {
        game_manager_script.instance.GameOver();
    }

    //set trollface to cloud that player touched
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cloud"))
        {
            audioManager.PlaySFX(audioManager.trollfaceLaugh);
            Vector3 cloudPosition = collision.transform.position;
            trollface_script.instance.TrollfaceSpawn(cloudPosition);
            game_manager_script.instance.GameOver();
        }
    }
}
