using UnityEngine;

public class LocalizedAudio : AudioComponent
{
    [SerializeField]
    private MultiLanguageAudioClip _multiLanguageAudioClip;

    private bool _initialized;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    private void Init()
    {
        if (_initialized)
            return;
        _initialized = true;
        if (_multiLanguageAudioClip != null)
            SetAudioClip(LanguageManager.GetAudioClip(_multiLanguageAudioClip));

        LanguageManager.Instance.OnLanguageChange += (language) => {
            if (this && gameObject && _multiLanguageAudioClip != null)
                SetMultiLanguageAudioClip(_multiLanguageAudioClip);
        };
    }

    public void SetMultiLanguageAudioClip(MultiLanguageAudioClip audio)
    {
        Init();
        _multiLanguageAudioClip = audio;
        if (_multiLanguageAudioClip != null)
            SetAudioClip(LanguageManager.GetAudioClip(_multiLanguageAudioClip));
    }
}