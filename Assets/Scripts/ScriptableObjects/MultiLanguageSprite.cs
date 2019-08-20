using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LanguageSpriteTuple
{
    public Language Language;
    public Sprite Sprite;
}
[CreateAssetMenu(
    fileName = "New MultiLanguageSprite",
    menuName = "Localization/MultiLanguageSprite",
    order = 1)]
public class MultiLanguageSprite : ScriptableObject
{
    public LanguageSpriteTuple[] _sprites;

    private Dictionary<Language, Sprite> _dictionary;

    private Dictionary<Language, Sprite> Dictionary
    {
        get
        {
            if (_dictionary == null)
            {
                _dictionary = new Dictionary<Language, Sprite>();
                foreach (var item in _sprites)
                {
                    if (item.Language == null)
                        Debug.LogError("Language empty for MultiLanguageSprite: " + this);
                    else
                        _dictionary[item.Language] = item.Sprite;
                }
            }
            return _dictionary;
        }
    }

    public Sprite GetSprite(Language language)
    {
        return Dictionary[language];
    }
}
