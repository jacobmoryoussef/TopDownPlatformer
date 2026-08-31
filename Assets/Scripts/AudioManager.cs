using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;

    [Header("Sounds")]
    [SerializeField] AudioClip MusicClip;
    [SerializeField] AudioClip Jump;


    void Start()
    {
        
        Music.clip = MusicClip;
        Music.Play();

    }

    public void PlayJumpSFX()
    {

        SFX.PlayOneShot(Jump);
    
    }

}
