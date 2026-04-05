using UnityEngine;
using UnityEngine.UI;

public class AvatarUploadPanel : MonoBehaviour
{
    [SerializeField] private InputField imagePathInput;
    [SerializeField] private RuntimeAvatarLoader runtimeAvatarLoader;

    public void LoadAvatarFromInput()
    {
        if (runtimeAvatarLoader == null || imagePathInput == null)
        {
            return;
        }

        runtimeAvatarLoader.LoadAvatarFromPath(imagePathInput.text);
    }

    public void ResetAvatar()
    {
        if (runtimeAvatarLoader != null)
        {
            runtimeAvatarLoader.ResetAvatar();
        }

        if (imagePathInput != null)
        {
            imagePathInput.text = string.Empty;
        }
    }
}
