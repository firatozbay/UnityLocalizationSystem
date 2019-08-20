using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    private List<Language> _languages;

    public Language SelectedLanguage { get; private set; }

    public Language _defaultLanguage;

    public event Action<Language> OnLanguageChange;

    private void Awake()
    {
        Instance = this;
        _languages = new List<Language>(
            Resources.LoadAll<Language>("Data/Localization/Languages"));
        SelectedLanguage = _defaultLanguage;
    }

    public void ToggleLanguage()
    {
        SelectedLanguage = _languages
            [(_languages.IndexOf(SelectedLanguage) + 1) % _languages.Count];
        OnLanguageChange.Invoke(SelectedLanguage);
    }

    public static string GetText(MultiLanguageText text, params object[] args)
    {
        return string.Format(text.GetString(Instance.SelectedLanguage), args);
    }

    public static Sprite GetSprite(MultiLanguageSprite sprite)
    {
        return sprite.GetSprite(Instance.SelectedLanguage);
    }

    public static VideoClip GetVideoClip(MultiLanguageVideoClip videoClip)
    {
        return videoClip.GetVideoClip(Instance.SelectedLanguage);
    }

    public static AudioClip GetAudioClip(MultiLanguageAudioClip audioClip)
    {
        return audioClip.GetAudioClip(Instance.SelectedLanguage);
    }
}
