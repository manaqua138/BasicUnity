using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance; //�ڱ� �ڽ��� ������

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
        myAudio = GetComponent<AudioSource>(); // Audio Source ������Ʈ ��������
        
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
