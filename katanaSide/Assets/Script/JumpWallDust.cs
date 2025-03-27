using UnityEngine;

public class JumpWallDust : MonoBehaviour
{
    public float lifetime = 0.5f;


    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}