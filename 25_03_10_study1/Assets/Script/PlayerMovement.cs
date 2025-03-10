using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    public float jumpForce = 5.0f; //������
    public int maxJumpCount = 2;
    private int jumpCount = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * speed * Time.deltaTime);

        //Space Ű�� ������ ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            //Rigidbody:����ȿ���� �߰��� �߷��� �����մϴ�.
            //AddFroce : ������ ���� ������Ʈ�� ���� �ݴϴ�.
            //ForceMode.Impulse : ���������� ���� ���ϴ� �ɼ�
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            jumpCount = 0;
    }




    
}
