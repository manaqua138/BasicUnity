using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameManager gm;

    int score = GameManager.instance.score;

    void SpawnEnemy1()
    {
        float randomX = Random.Range(-2f, 2f);
        Instantiate(enemy, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }

    void SpawnEnemy2()
    {
        float randomX = Random.Range(-2f, 2f);
        Instantiate(enemy, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }

    void SpawnEnemy3()
    {
        float randomX = Random.Range(-2f, 2f);
        Instantiate(enemy, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }



    void Start()
    {
            InvokeRepeating("SpawnEnemy1", 1, 0.5f);
        
        if (score > 500)
            InvokeRepeating("SpawnEnemy2", 1, 0.5f);

        if (score > 1000) 
            InvokeRepeating("SpawnEnemy3", 1, 0.5f);
        
        
    }

    void Update()
    {
        
    }
}
