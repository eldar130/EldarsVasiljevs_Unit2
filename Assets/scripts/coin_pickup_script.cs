using UnityEngine;

public class coin_pickup_script : MonoBehaviour
{
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // when player picks up coin add 5 and destroy object
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.coinPickup);
            score.instance.UpdateScore(5);
            Destroy(gameObject);
        }
    }
}
