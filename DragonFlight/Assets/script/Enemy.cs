using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // ������ �ӵ��� ������ �ش�
    public float moveSpeed = 1.3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceY = moveSpeed * Time.deltaTime;

        transform.Translate(0, -distanceY, 0);
        
    }

    //ȭ�� ������ ���� ī�޶󿡼� ������ ������ ȣ��ȴ�.

    private void OnBecameInvisible()
    {
        Destroy(gameObject); //��ü�� �����Ѵ�.
    }


}
