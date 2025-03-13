using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;
    private int bulletLevel = 0;

    Animator ani; //애니메이터를 가져올 변수

    public GameObject[] bullets = new GameObject[4];

    public Transform pos = null;

    //아이템

    //레이져

    void Start()
    {
        ani = GetComponent<Animator>();
    
    }

    void Update()
    {
        //방향키에따른 움직임
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

        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) //이게 == 보다 좀 더 엄밀하게 측정
        {

            if(bulletLevel < 3) { bulletLevel += 1; }
            Destroy(collision.gameObject);
            Debug.Log("bulletLevel :  " + bulletLevel);


        }
    }

    private void FireBullet()
    {
        if (bulletLevel >= 0 && bulletLevel < bullets.Length) // bulletLevel이 배열 범위 내인지 확인
        {
            Instantiate(bullets[bulletLevel], pos.position, Quaternion.identity);
            SoundManage.instance.PlaySoundBullet();
        }
    }




}