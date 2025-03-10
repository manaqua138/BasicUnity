using UnityEngine;

public class LoopExample : MonoBehaviour
{
    void Start()
    {
        ////for 문 1
        //for(int i = 0; i <= 10; i++)
        //{
        //    Debug.Log("Count : " + i);
        //}
        //한글은 오류

        int count = 0;
        while(count < 5)
        {

            Debug.Log("count : " + count);
            count++;

        }
       



    }


}
