using System.Collections;
using UnityEngine;

public class SpawManage : MonoBehaviour
{
    public GameObject monster1;
    public GameObject monster2;
    public float ss = -2;
    public float es = 2;
    public float StartTime = 1;
    public float SpawnStop = 10;

    bool swi1 = true;
    bool swi2 = true;

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);
    }

    IEnumerator RandomSpawn()
    {
        while(swi1)
        {
            yield return new WaitForSeconds(StartTime);
            float x = Random.Range(ss, es);
            Vector2 r = new Vector2(x, transform.position.y);

            Instantiate(monster1, r, Quaternion.identity);

        }
    }

    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            yield return new WaitForSeconds(StartTime + 2);
            float x = Random.Range(ss, es);
            Vector2 r = new Vector2(x, transform.position.y);

            Instantiate(monster2, r, Quaternion.identity);

        }
    }

    void Stop()
    {
        swi1 = false;
        //두 번쨰 몬스터 코루틴
        StopCoroutine("RandomSpawn");

        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", SpawnStop + 20);
    }

    void Stop2()
    {
        swi2 = false;
        //두 번쨰 몬스터 코루틴
        StopCoroutine("RandomSpawn2");

        //StartCoroutine("RandomSpawn2");
    }


    void Update()
    {
        
    }
}
