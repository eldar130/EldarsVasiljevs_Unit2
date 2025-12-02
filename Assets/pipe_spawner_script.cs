using UnityEngine;

public class pipe_spawner_script : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2.5f;
    [SerializeField] private float heightTop = 1.1f;
    [SerializeField] private float heightBottom = -0.7f;
    [SerializeField] private GameObject pipe;
    private float timer;

    void Start()
    {
        spawner();
    }

    void Update()
    {
        if(timer >= spawnTime)
        {
            spawner();
            timer = 0;
        }
    timer  += Time.deltaTime;
    }

    void spawner()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(heightBottom, heightTop));
        GameObject pipes = Instantiate(pipe, spawnPos, Quaternion.identity);

        Destroy(pipes, 8f);
    }
}
