using Unity.VisualScripting;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    
    //유니티에서 싱글톤을 사용하면 하나의 인스턴스만 유지하면서 어디서든 접근 가능하게 만들 수 있다.
    public static Singleton Instance { get; private set; }

    //함수 한 번 실행하는건데 start 보다 더 빠른 실행
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //씬이 바뀌어도 유지되게하는 함수
        }
        else
        {
            Destroy(gameObject); //증복생성 방지
        }
    }

    public void PrintMessage()
    {
        Debug.Log("싱글톤 메세지 출력!");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
