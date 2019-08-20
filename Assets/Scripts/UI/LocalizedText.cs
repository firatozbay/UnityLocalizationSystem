﻿using UnityEngine;
using TMPro;
using RTLTMPro;


public class LocalizedText : TextComponent
{
    private TMP_FontAsset _latinFont;

    private TextAlignmentOptions _latinAlignment;

    [SerializeField]
    private MultiLanguageText _multiLanguageText;

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
        if (TextPro)
        {
            _latinFont = TextPro.font;
            _latinAlignment = TextPro.alignment;
        }
        if (_multiLanguageText != null)
            SetText(LanguageManager.GetText(_multiLanguageText));

        LanguageManager.Instance.OnLanguageChange += (language) => {
            if (this && gameObject && _multiLanguageText != null)
                SetMultiLanguageText(_multiLanguageText);
        };
    }

    public void SetMultiLanguageText(MultiLanguageText text)
    {
        Init();
        //var font = LanguageManager.Instance.AlphabetFontMatrix.GetFont(
        //    _latinFont,LanguageManager.Instance.SelectedLanguage);
        //if (font)
        //    TextPro.font = font;
        if(TextPro)
            TextPro.alignment = GetAlignment(LanguageManager.Instance.SelectedLanguage);
        _multiLanguageText = text;
        if (_multiLanguageText != null)
            SetText(LanguageManager.GetText(_multiLanguageText));
    }

    private TextAlignmentOptions GetAlignment(Language language)
    {
        if (language.ReadOrder == ReadOrder.LTR)
            return _latinAlignment;
        //RTL
        if(_latinAlignment == TextAlignmentOptions.Center ||
            _latinAlignment == TextAlignmentOptions.CenterGeoAligned|| 
            _latinAlignment == TextAlignmentOptions.Top||
            _latinAlignment == TextAlignmentOptions.Bottom)
        {
            return _latinAlignment;
        }
        if(_latinAlignment == TextAlignmentOptions.Right
            || _latinAlignment == TextAlignmentOptions.Left)
        {
            return TextAlignmentOptions.Right;
        }
        if (_latinAlignment == TextAlignmentOptions.BottomRight
            || _latinAlignment == TextAlignmentOptions.BottomLeft)
        {
            return TextAlignmentOptions.BottomRight;
        }
        if (_latinAlignment == TextAlignmentOptions.TopRight
            || _latinAlignment == TextAlignmentOptions.TopLeft)
        {
            return TextAlignmentOptions.TopRight;
        }
        return _latinAlignment;
    }
}