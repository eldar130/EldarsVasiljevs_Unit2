using UnityEngine;

public class trollface_script : MonoBehaviour
{
        void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] private GameObject trollface;
    [SerializeField] private Vector3 spawnOffset;
    public static trollface_script instance;

    public void TrollfaceSpawn(Vector3 spawnPosition)
    {
        Instantiate(trollface, spawnPosition + spawnOffset, Quaternion.identity);
    }
}