using UnityEngine;
using UnityEngine.UI;

public class ImageComponent : MonoBehaviour
{

    private Image _image;

    protected virtual void Awake()
    {
        _image = GetComponent<Image>();
    }

    protected void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
