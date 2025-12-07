using UnityEngine;
using System.Collections;

public class coin_movement_script : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;
    private bool isPaused = false;
    private float previousX;

    void Update()
    {
        if (isPaused) return;

        previousX = transform.position.x;

        // Move the coin left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Detect crossing x = 0 from positive side
        if (previousX > 0f && transform.position.x <= 0f)
        {
            StartCoroutine(PauseAtZero());
        }
    }

    private IEnumerator PauseAtZero()
    {
        isPaused = true;

        // Snap to exactly 0
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);

        // Pause for 2 seconds
        yield return new WaitForSeconds(2f);

        // Resume movement
        isPaused = false;
    }
}
