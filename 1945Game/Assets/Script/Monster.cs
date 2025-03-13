using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 3f;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;


    void Start()
    {
        //한 번 함수 호출, 이 후 반복
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //재귀 호출
        Invoke("CreateBullet", Delay);
    }



    void Update()
    {
        //아래 방향으로 이동
        transform.Translate(Vector3.down * Speed * Time.deltaTime);


    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }





}
