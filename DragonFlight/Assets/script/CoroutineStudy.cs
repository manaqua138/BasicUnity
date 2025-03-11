using UnityEngine;
using System.Collections; // 추가해야 할 수도 있음

public class CoroutineStudy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("ExampleCoroutine");
    }

    IEnumerator ExampleCoroutine() //  올바른 위치에서 선언
    {
        while (true)
        {
            Debug.Log("코루틴 시작");
            yield return new WaitForSeconds(2f);
            Debug.Log("2초 마다 실행");
        }
    }
}
