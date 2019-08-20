using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public abstract class AudioComponent : MonoBehaviour
{
    private AudioSource _audioSource;

    protected virtual void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    protected void SetAudioClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
    }

    public void Play()
    {
        _audioSource.Play();
    }
}
