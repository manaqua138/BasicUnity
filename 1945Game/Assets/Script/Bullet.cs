using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.7f;
    //���ݷ�
    //����Ʈ
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
        if (collision.gameObject.CompareTag("Monster")) //�̰� == ���� �� �� �����ϰ� ����
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
        //Debug.Log("���� ��: " + rand); // ���� �� Ȯ��

        if (Item == null)
        {
            Debug.LogError("Item �������� �Ҵ���� �ʾҽ��ϴ�! Unity Inspector���� Ȯ���ϼ���.");
            return;
        }

        if (rand < 25)
        {
            Instantiate(Item, position, Quaternion.identity);
            //Debug.Log("������ ����!");
        }
        else
        {
            //Debug.Log("������ �̻���.");
        }
    }





}
