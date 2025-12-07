using UnityEngine;

public class pipe_increase_score_script : MonoBehaviour
{
    //increase score by 1 when player passes the pipes
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score.instance.UpdateScore(1);
        }
    }
}
