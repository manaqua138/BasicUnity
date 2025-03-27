using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("�÷��̾� �Ӽ�")]
    public float speed = 5;
    public float jumpUp = 1;
    public float power = 5;
    public Vector3 direction;
    public GameObject slash;
    public Transform pos;

    //�׸���
    public GameObject Shadow1;
    List<GameObject> sh = new List<GameObject>();

    //��Ʈ ����Ʈ
    public GameObject hit_lazer;
    public GameObject jumpDust;
    public GameObject wallDust;


    bool bJump = false;
    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;

    //������
    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask wLayer;
    bool isWall;
    public float slidingSpeed;
    public float wallJumpPower;
    public bool isWallJump;
    float isRight = 1;



    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();

    }


    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal"); //������ -1   0   1

        if (direction.x < 0)
        {
            //left
            sp.flipX = true;
            pAnimator.SetBool("Run", true);

            //���� �� ����
            isRight = -1;

            //Shadowflip
            for (int i = 0; i < sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }

        }
        else if (direction.x > 0)
        {
            //right
            sp.flipX = false;
            pAnimator.SetBool("Run", true);

            //���� �� ����
            isRight = 1;

            //Shadowflip
            for (int i = 0; i < sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }


        }
        else if (direction.x == 0)
        {
            pAnimator.SetBool("Run", false);


            for (int i = 0; i < sh.Count; i++)
            {
                Destroy(sh[i]); //���ӿ�����Ʈ�����
                sh.RemoveAt(i); //���ӿ�����Ʈ �����ϴ� ����Ʈ�����
            }

        }


        if (Input.GetMouseButtonDown(0)) //0�� ���ʸ��콺
        {
            pAnimator.SetTrigger("Attack");
            
        }


    }


    void Update()
    {
        if(!isWallJump)
        {
            KeyInput();
            Move();
        }
    

        //������ üũ
        isWall = Physics2D.Raycast(wallChk.position, Vector2.right * isRight, wallchkDistance, wLayer);
        pAnimator.SetBool("Grab", isWall);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (pAnimator.GetBool("Jump") == false)
            {
                Jump();
                JumpDust();
                pAnimator.SetBool("Jump", true);

            }

        }

        if(isWall)
        {
            isWall = false;
            //�� ���� ����
            pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocityX, pRig2D.linearVelocityY * slidingSpeed);
            //���� ��� �ִ� ���¿��� ����
            if(Input.GetKeyDown(KeyCode.W))
            {
                isWallJump = true;
                //������ ����
                GameObject go = Instantiate(wallDust, transform.position + new Vector3(0.8f * isRight, 0, 0), Quaternion.identity);
                go.GetComponent<SpriteRenderer>().flipX = sp.flipX;

                Invoke("FreezeX", 0.3f);

                //���� ����ȭ
                pRig2D.linearVelocity = new Vector2(-isRight * wallJumpPower, 0.9f * wallJumpPower);

                sp.flipX = sp.flipX == false ? true : false;
                isRight = -isRight;
             
            }

        }

    }

    void FreezeX()
    {
        isWallJump = false;
    }


    private void FixedUpdate()
    {
        Debug.DrawRay(pRig2D.position, Vector3.down, new Color(0, 1, 0));

        //����ĳ��Ʈ�� ��üũ 
        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if (pRig2D.linearVelocityY < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.7f)
                {
                    pAnimator.SetBool("Jump", false);
                }
            }
            else
            {
                if(!isWall)
                {
                    pAnimator.SetBool("Jump", true);
                }
                else
                {
                    pAnimator.SetBool("Grab", true);
                }
            }
        }


    }

    public void Jump()
    {
        pRig2D.linearVelocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);

    }

    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void AttSlash()
    {
        //�÷��̾� ������
        if (sp.flipX == false)
        {
            pRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
            //�÷��̾� ������
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }
        else
        {

            pRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            //����
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }

    }

    //�׸���
    public void RunShadow()
    {
        if (sh.Count < 6)
        {
            GameObject go = Instantiate(Shadow1, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().TwSpeed = 10 - sh.Count;
            sh.Add(go);
        }
    }

    public void CreateHitLazer()
    {
        Instantiate(hit_lazer, transform.position, Quaternion.identity);
    }

    public void RandDust(GameObject dust)
    {
        Instantiate(dust, pos.transform.position, Quaternion.identity);
    }

    public void JumpDust()
    {    
            Instantiate(jumpDust, transform.position, Quaternion.identity);            
    }

    public void WallDust()
    {
        Instantiate(wallDust, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallChk.position, Vector2.right * isRight * wallchkDistance);
    }




}
