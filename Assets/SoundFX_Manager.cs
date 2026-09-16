using Unity.VisualScripting;
using UnityEngine;

public class SoundFX_Manager : MonoBehaviour
{

    public static SoundFX_Manager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLenth = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLenth);
    }


}
