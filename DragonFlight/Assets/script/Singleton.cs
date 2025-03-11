using Unity.VisualScripting;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    
    //����Ƽ���� �̱����� ����ϸ� �ϳ��� �ν��Ͻ��� �����ϸ鼭 ��𼭵� ���� �����ϰ� ���� �� �ִ�.
    public static Singleton Instance { get; private set; }

    //�Լ� �� �� �����ϴ°ǵ� start ���� �� ���� ����
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //���� �ٲ� �����ǰ��ϴ� �Լ�
        }
        else
        {
            Destroy(gameObject); //�������� ����
        }
    }

    public void PrintMessage()
    {
        Debug.Log("�̱��� �޼��� ���!");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
