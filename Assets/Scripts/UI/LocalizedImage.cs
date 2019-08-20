using UnityEngine;

public class LocalizedImage : ImageComponent
{
    [SerializeField]
    private MultiLanguageSprite _multiLanguageSprite;

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
        if (_multiLanguageSprite != null)
            SetSprite(LanguageManager.GetSprite(_multiLanguageSprite));

        LanguageManager.Instance.OnLanguageChange += (language) => {
            if (this && gameObject && _multiLanguageSprite != null)
                SetMultiLanguageSprite(_multiLanguageSprite);
        };
    }

    public void SetMultiLanguageSprite(MultiLanguageSprite sprite)
    {
        Init();
        _multiLanguageSprite = sprite;
        if (_multiLanguageSprite != null)
            SetSprite(LanguageManager.GetSprite(_multiLanguageSprite));
    }
}