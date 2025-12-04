using UnityEngine;

public class coin_spawner_script : MonoBehaviour
{
    [SerializeField] private float spawnTime = 36.25f;
    [SerializeField] private float rangeTop = 1.8f;
    [SerializeField] private float rangeBottom = -1.1f;
    [SerializeField] private GameObject coin;
    private float timer;

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
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(rangeBottom, rangeTop));
        GameObject coins = Instantiate(coin, spawnPos, Quaternion.identity);

        Destroy(coins, 11f);
    }
}
