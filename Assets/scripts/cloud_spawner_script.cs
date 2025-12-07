using UnityEngine;

public class cloud_spawner_script : MonoBehaviour
{
    [SerializeField] private float rangeBottom = 0f;
    [SerializeField] private float rangeTop = 0.4f;
    [SerializeField] private GameObject cloud;
    private float spawnTime;
    private float timer;

    void Start()
    {
        SetNewSpawnTime();
    }

    void Update()
    {
        if(timer >= spawnTime)
            {
                spawner();
                SetNewSpawnTime();
                timer = 0;
            }
        timer  += Time.deltaTime; 
    }

    void SetNewSpawnTime()
    {
        spawnTime = Random.Range(1.5f, 4f);
    }

    void spawner()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(rangeBottom, rangeTop));
        GameObject clouds = Instantiate(cloud, spawnPos, Quaternion.identity);

        Destroy(clouds, 8f);
    }
}
