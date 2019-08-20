using UnityEngine;

public class LocalizedVideo : VideoComponent
{
    [SerializeField]
    private MultiLanguageVideoClip _multiLanguageVideoClip;

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
        if (_multiLanguageVideoClip != null)
            SetVideoClip(LanguageManager.GetVideoClip(_multiLanguageVideoClip));

        LanguageManager.Instance.OnLanguageChange += (language) => {
            if (this && gameObject && _multiLanguageVideoClip != null)
                SetMultiLanguageVideoClip(_multiLanguageVideoClip);
        };
    }

    public void SetMultiLanguageVideoClip(MultiLanguageVideoClip text)
    {
        Init();
        _multiLanguageVideoClip = text;
        if (_multiLanguageVideoClip != null)
            SetVideoClip(LanguageManager.GetVideoClip(_multiLanguageVideoClip));
    }
}