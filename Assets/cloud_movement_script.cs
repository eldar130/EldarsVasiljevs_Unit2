using UnityEngine;

public class cloud_movement_script : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
