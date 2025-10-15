using UnityEngine;

public class SoundHandlerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pickupSound;
    public AudioClip combine;
    public AudioClip feed;
    public AudioClip trash;
    public AudioClip correct;
    public AudioClip wrong;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // PlayPickupSound(); // testing
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayPickupSound()
    {
        audioSource.PlayOneShot(pickupSound);
    }

    public void PlayCombineSound()
    {
        audioSource.PlayOneShot(combine);
    }

    public void PlayFeedSound()
    {
        audioSource.PlayOneShot(feed);
    }

    public void PlayTrashSound()
    {
        audioSource.PlayOneShot(trash);
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correct);
    }

    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(wrong);
    }

}
