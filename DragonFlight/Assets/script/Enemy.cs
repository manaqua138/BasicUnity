using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 움직일 속도를 지정해 준다
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

    //화면 밖으로 나가 카메라에서 보이지 않으면 호출된다.

    private void OnBecameInvisible()
    {
        Destroy(gameObject); //객체를 삭제한다.
    }


}
