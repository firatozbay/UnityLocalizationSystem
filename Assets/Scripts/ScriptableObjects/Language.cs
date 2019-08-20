using UnityEngine;

public enum ReadOrder { RTL, LTR }
[CreateAssetMenu(
    fileName = "New Language",
    menuName = "Localization/Language",
    order = 2)]
public class Language : ScriptableObject
{
    public ReadOrder ReadOrder;

    public string Name;
    
    public SystemLanguage SystemLanguageType;
}
