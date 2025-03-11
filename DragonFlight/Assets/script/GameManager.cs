using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{

    public static GameManage instance;
    public Text scoreText;
    public Text StartText;

    int score = 0; //정수를 관리

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        int i = 3;
        while(i>0)
        {
            StartText.text = i.ToString();

            yield return new WaitForSeconds(1);
            i--;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false);
            }
        }
    }



    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }



    void Update()
    {
        
    }
}
