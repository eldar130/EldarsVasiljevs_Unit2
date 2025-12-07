using UnityEngine;

public class pipe_movement : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
