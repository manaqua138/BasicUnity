using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    public float jumpForce = 5.0f; //점프힘
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

        //Space 키를 누르면 점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            //Rigidbody:물리효과를 추가해 중력을 적용합니다.
            //AddFroce : 점프를 위해 오브젝트에 힘을 줍니다.
            //ForceMode.Impulse : 순간적으로 힘을 가하는 옵션
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
