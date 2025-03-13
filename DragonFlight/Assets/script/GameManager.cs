using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //�̱���
    //��𿡼��� ���� �Ҽ� �ֵ��� static(����)���� �ڱ��ڽ��� �����ؼ� �̱����̶�� ������������ 
    //����غ���.
    public static GameManager instance;
    public Text scoreText; //������ ǥ���ϴ� Text��ü�� �����Ϳ��� �޾ƿɴϴ�.
    public Text StartText; //���ӽ�����3,2,1

    public int score = 0; //������ �����մϴ�.

    private void Awake()
    {
        if (instance == null) //�������� �ڽ��� üũ�մϴ�. null����
        {
            instance = this; //�ڱ��ڽ��� �����Ѵ�.
        }
    }

    void Start()
    {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        int i = 3;
        Time.timeScale = 0;

        while (i > 0)
        {
            StartText.text = i.ToString();

            yield return new WaitForSecondsRealtime(1);

            i--;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false);  //UI���߱�
                Time.timeScale = 1;
            }
        }
    }





    public void AddScore(int num)
    {
        score += num; //������ �����ݴϴ�.
        scoreText.text = "Score : " + score; //�ؽ�Ʈ�� �ݿ��մϴ�.
    }

    public int GetScore() { return score; }



}