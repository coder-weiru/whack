using UnityEngine;
using UnityEngine.UI;

public class AvatarFaceView : MonoBehaviour
{
    [SerializeField] private Image faceImage;
    [SerializeField] private Sprite fallbackSprite;
    [SerializeField] private bool preserveAspect = true;

    private Sprite runtimeSprite;

    private void Awake()
    {
        ApplyFallbackIfNeeded();
    }

    public void SetAvatar(Sprite sprite)
    {
        if (faceImage == null || sprite == null)
        {
            return;
        }

        faceImage.sprite = sprite;
        faceImage.preserveAspect = preserveAspect;
    }

    public void SetAvatar(Texture2D texture)
    {
        if (texture == null)
        {
            return;
        }

        if (runtimeSprite != null)
        {
            Destroy(runtimeSprite);
        }

        runtimeSprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            100f);

        SetAvatar(runtimeSprite);
    }

    public void ResetAvatar()
    {
        if (faceImage == null)
        {
            return;
        }

        faceImage.sprite = fallbackSprite;
        faceImage.preserveAspect = preserveAspect;
    }

    private void ApplyFallbackIfNeeded()
    {
        if (faceImage == null)
        {
            return;
        }

        if (faceImage.sprite == null && fallbackSprite != null)
        {
            faceImage.sprite = fallbackSprite;
            faceImage.preserveAspect = preserveAspect;
        }
    }
}
