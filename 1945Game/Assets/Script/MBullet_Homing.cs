using UnityEngine;

public class MBullet_Homing : MonoBehaviour
{
    public GameObject target;
    public float Speed = 3f;
    Vector2 dir;



    void Start()
    {
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        //플레이어 - 미사일 
        dir = target.transform.position - transform.position;


    }


    void Update()
    {
        transform.Translate(dir.normalized * Speed * Time.deltaTime);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //플레이어 지우기
            
            Destroy(gameObject);
        }
    }

}
