using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LanguageAudioClipTuple
{
    public Language Language;
    public AudioClip AudioClip;
}
[CreateAssetMenu(
    fileName = "New MultiLanguageAudioClip",
    menuName = "Localization/MultiLanguageAudioClip",
    order = 1)]
public class MultiLanguageAudioClip : ScriptableObject
{
    public LanguageAudioClipTuple[] videoClips;

    private Dictionary<Language, AudioClip> _dictionary;

    private Dictionary<Language, AudioClip> Dictionary
    {
        get
        {
            if (_dictionary == null)
            {
                _dictionary = new Dictionary<Language, AudioClip>();
                foreach (var item in videoClips)
                {
                    if (item.Language == null)
                        Debug.LogError("Language empty for MultiLanguageAudioClip: " + this);
                    else
                        _dictionary[item.Language] = item.AudioClip;
                }
            }
            return _dictionary;
        }
    }

    public AudioClip GetAudioClip(Language language)
    {
        return Dictionary[language];
    }
}
