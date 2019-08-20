using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonComponent : MonoBehaviour
{
    private Button _button;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => OnClick());
    }

    protected abstract void OnClick();

    protected virtual void Enable(bool enable)
    {
        _button.enabled = enable;
    }
}
