using UnityEngine;

public class Scr_audio : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSrc;
    public void StartParent()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public void play()
    {
        audioSrc.PlayOneShot(audioSrc.clip);
    }
    public void playRand() 
    {
        audioSrc.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
        play();
    }
    public void playSound(int i = 0)
    {
        audioSrc.clip = clips[i];
        play();
    }
    public float getSoundLength()
    {
        return audioSrc.clip.length;
    }
}
