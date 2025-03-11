using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject bullet; //�̻��� ������ ������ ����
    public float bullet_delay = 0.3f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating(�Լ��̸�, �ʱ������ð�, ������ �ð�)
        InvokeRepeating("Shoot", 0.5f, bullet_delay);

    }

    void Shoot()
    {
        //�̻��� ������, ���� ������, ���Ⱚ ����
        Instantiate(bullet, transform.position, Quaternion.identity);

        //���� ����غ���
        SoundManager.instance.PlayBulletSound();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
