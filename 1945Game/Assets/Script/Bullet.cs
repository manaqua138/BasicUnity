using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.7f;
    //공격력
    //이펙트
    public GameObject effect;
    public GameObject Item;



    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if(collision.gameObject.tag == "Enemy")
        if (collision.gameObject.CompareTag("Monster")) //이게 == 보다 좀 더 엄밀하게 측정
        {

            
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
          
            Destroy(collision.gameObject);

            Destroy(gameObject);

            CreateItem(collision.transform.position);


        }


    }

    private void CreateItem(Vector3 position)
    {
        float rand = Random.Range(0, 100);
        //Debug.Log("랜덤 값: " + rand); // 랜덤 값 확인

        if (Item == null)
        {
            Debug.LogError("Item 프리팹이 할당되지 않았습니다! Unity Inspector에서 확인하세요.");
            return;
        }

        if (rand < 25)
        {
            Instantiate(Item, position, Quaternion.identity);
            //Debug.Log("아이템 생성!");
        }
        else
        {
            //Debug.Log("아이템 미생성.");
        }
    }





}
