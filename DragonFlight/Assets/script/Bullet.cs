using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject exposion;
    public float moveSpeed = 0.7f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        //if(collision.gameObject.tag == "Enemy")
        if(collision.gameObject.CompareTag("Enemy")) //이게 == 보다 좀 더 엄밀하게 측정
        {
            Instantiate(exposion, transform.position, Quaternion.identity);

            SoundManager.instance.SoundDie();

            GameManager.instance.AddScore(10);

            Destroy(collision.gameObject);
            Destroy(gameObject);

         
        }


    }




}
