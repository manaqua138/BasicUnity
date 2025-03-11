using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f);
        Instantiate(enemy, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 0.5f);

    }

    void Update()
    {
        
    }
}
