using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //���ǵ�
    public float moveSpeed = 5f;
    private int bulletLevel = 0;

    Animator ani; //�ִϸ����͸� ������ ����

    public GameObject[] bullets = new GameObject[4];

    public Transform pos = null;

    //������

    //������

    void Start()
    {
        ani = GetComponent<Animator>();
    
    }

    void Update()
    {
        //����Ű������ ������
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1   0   1
        if (Input.GetAxis("Horizontal") <= -0.5f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.5f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);


        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }


        transform.Translate(moveX, moveY, 0);

        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) //�̰� == ���� �� �� �����ϰ� ����
        {

            if(bulletLevel < 3) { bulletLevel += 1; }
            Destroy(collision.gameObject);
            Debug.Log("bulletLevel :  " + bulletLevel);


        }
    }

    private void FireBullet()
    {
        if (bulletLevel >= 0 && bulletLevel < bullets.Length) // bulletLevel�� �迭 ���� ������ Ȯ��
        {
            Instantiate(bullets[bulletLevel], pos.position, Quaternion.identity);
            SoundManage.instance.PlaySoundBullet();
        }
    }




}