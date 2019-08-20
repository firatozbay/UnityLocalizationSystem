using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public abstract class VideoComponent : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    protected virtual void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    protected void SetVideoClip(VideoClip videoClip)
    {
        _videoPlayer.clip = videoClip;
    }

    public void Play()
    {
        _videoPlayer.Play();
    }
}
