using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeAvatarLoader : MonoBehaviour
{
    [SerializeField] private AvatarFaceView avatarFaceView;
    [SerializeField] private Text feedbackText;

    public void LoadAvatarFromPath(string filePath)
    {
        if (avatarFaceView == null)
        {
            SetFeedback("Assign AvatarFaceView first.");
            return;
        }

        if (string.IsNullOrWhiteSpace(filePath))
        {
            SetFeedback("Enter an image path first.");
            return;
        }

        if (!File.Exists(filePath))
        {
            SetFeedback("Image file not found.");
            return;
        }

        byte[] imageBytes = File.ReadAllBytes(filePath);
        Texture2D avatarTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);

        if (!ImageConversion.LoadImage(avatarTexture, imageBytes))
        {
            Destroy(avatarTexture);
            SetFeedback("Could not decode the image.");
            return;
        }

        avatarFaceView.SetAvatar(avatarTexture);
        SetFeedback("Avatar loaded.");
    }

    public void ResetAvatar()
    {
        if (avatarFaceView != null)
        {
            avatarFaceView.ResetAvatar();
            SetFeedback("Avatar reset.");
        }
    }

    private void SetFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
        }
    }
}
