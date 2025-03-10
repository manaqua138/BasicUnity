using UnityEngine;

public class ConditionExample : MonoBehaviour
{
    public int health = 100;

    // Update is called once per frame
    void Update()
    {
        health -= 1;
        Debug.Log("Health : " + health);

        if(health <=0 )
        {
            Debug.Log("Game Over!");
        }
    }
}
