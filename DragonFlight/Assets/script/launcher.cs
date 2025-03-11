using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject bullet; //미사일 프리펩 가져올 변수
    public float bullet_delay = 0.3f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating(함수이름, 초기지연시간, 지연할 시간)
        InvokeRepeating("Shoot", 0.5f, bullet_delay);

    }

    void Shoot()
    {
        //미사일 프리팹, 런쳐 포지션, 방향값 안줌
        Instantiate(bullet, transform.position, Quaternion.identity);

        //사운드 사용해보기
        SoundManager.instance.PlayBulletSound();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
