using UnityEngine;

public class MBullet_Homing : MonoBehaviour
{
    public GameObject target;
    public float Speed = 3f;
    Vector2 dir;



    void Start()
    {
        //�÷��̾� �±׷� ã��
        target = GameObject.FindGameObjectWithTag("Player");
        //�÷��̾� - �̻��� 
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
            //�÷��̾� �����
            
            Destroy(gameObject);
        }
    }

}
