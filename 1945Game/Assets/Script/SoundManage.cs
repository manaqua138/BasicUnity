using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public static SoundManage instance; // ΩÃ±€≈Ê

    AudioSource myAudio;
    public AudioClip soundBullet;
    public AudioClip soundDie;
    public AudioClip soundEatItem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }


    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlaySoundDie() { myAudio.PlayOneShot(soundDie); }
    public void PlaySoundBullet() { myAudio.PlayOneShot(soundBullet); }
    public void PlaySoundEatItem() { myAudio.PlayOneShot(soundEatItem); }






    void Update()
    {
        
    }
}
