using UnityEngine;

public class Launchar : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bullet_delay = 0.3f;
    private bool isShooting = false; // �Ѿ� �߻簡 ���� ������ Ȯ���ϴ� ����

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            isShooting = true;
            InvokeRepeating("Shoot", 0, bullet_delay); // ���� �������� �ݺ� ����
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
            CancelInvoke("Shoot"); // Space Ű�� ���� �Ѿ� �߻縦 ����
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        SoundManage.instance.PlaySoundBullet();
    }
}
