using UnityEngine;
using System.Collections; // �߰��ؾ� �� ���� ����

public class CoroutineStudy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("ExampleCoroutine");
    }

    IEnumerator ExampleCoroutine() //  �ùٸ� ��ġ���� ����
    {
        while (true)
        {
            Debug.Log("�ڷ�ƾ ����");
            yield return new WaitForSeconds(2f);
            Debug.Log("2�� ���� ����");
        }
    }
}
