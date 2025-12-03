using UnityEngine;

public class pipe_increase_score_script : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score.instance.UpdateScore(); 
        }
    }
}
