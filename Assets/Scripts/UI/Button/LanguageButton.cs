using UnityEngine.UI;
using RTLTMPro;
using UnityEngine;

public class LanguageButton : ButtonComponent
{
    protected override void OnClick()
    {
        LanguageManager.Instance.ToggleLanguage();
    }
}
