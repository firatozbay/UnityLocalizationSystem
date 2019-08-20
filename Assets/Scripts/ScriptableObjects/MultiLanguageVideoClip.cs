using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[Serializable]
public struct LanguageVideoClipTuple
{
    public Language Language;
    public VideoClip VideoClip;
}
[CreateAssetMenu(
    fileName = "New MultiLanguageVideoClip",
    menuName = "Localization/MultiLanguageVideoClip",
    order = 1)]
public class MultiLanguageVideoClip : ScriptableObject
{
    public LanguageVideoClipTuple[] videoClips;

    private Dictionary<Language, VideoClip> _dictionary;

    private Dictionary<Language, VideoClip> Dictionary
    {
        get
        {
            if (_dictionary == null)
            {
                _dictionary = new Dictionary<Language, VideoClip>();
                foreach (var item in videoClips)
                {
                    if (item.Language == null)
                        Debug.LogError("Language empty for MultiLanguageVideoClip: " + this);
                    else
                        _dictionary[item.Language] = item.VideoClip;
                }
            }
            return _dictionary;
        }
    }

    public VideoClip GetVideoClip(Language language)
    {
        return Dictionary[language];
    }
}
