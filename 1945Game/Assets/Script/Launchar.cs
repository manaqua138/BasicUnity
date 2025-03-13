using UnityEngine;

public class Launchar : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bullet_delay = 0.3f;
    private bool isShooting = false; // 총알 발사가 진행 중인지 확인하는 변수

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            isShooting = true;
            InvokeRepeating("Shoot", 0, bullet_delay); // 일정 간격으로 반복 실행
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
            CancelInvoke("Shoot"); // Space 키를 떼면 총알 발사를 멈춤
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        SoundManage.instance.PlaySoundBullet();
    }
}
