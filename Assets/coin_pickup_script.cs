using UnityEngine;

public class coin_pickup_script : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // when player picks up coin add 5 and destroy object
        if (collision.gameObject.CompareTag("Player"))
        {
            score.instance.UpdateScore(84); // change back to 5
            Destroy(gameObject);
        }
    }
}
