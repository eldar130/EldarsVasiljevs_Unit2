using UnityEngine;

public class coin_pickup_script : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score.instance.UpdateScore(5); // Add 5 points
            Destroy(gameObject); // Remove the coin after pickup
        }
    }
}
