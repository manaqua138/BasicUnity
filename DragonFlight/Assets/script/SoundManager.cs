using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance; //자기 자신을 변수로

    AudioSource myAudio;
    public AudioClip soundBullet;
    public AudioClip soundDie;


    private void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); // Audio Source 컴포넌트 가져오기
        
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(soundBullet);
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
