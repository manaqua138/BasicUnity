using UnityEngine;

public class LoopExample : MonoBehaviour
{
    void Start()
    {
        ////for �� 1
        //for(int i = 0; i <= 10; i++)
        //{
        //    Debug.Log("Count : " + i);
        //}
        //�ѱ��� ����

        int count = 0;
        while(count < 5)
        {

            Debug.Log("count : " + count);
            count++;

        }
       



    }


}
