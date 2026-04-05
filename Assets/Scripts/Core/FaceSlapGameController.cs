using UnityEngine;
using UnityEngine.UI;

public class FaceSlapGameController : MonoBehaviour
{
    [SerializeField] private SlappableFace slappableFace;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text statusText;

    private int score;

    private void Awake()
    {
        if (slappableFace == null)
        {
            slappableFace = FindObjectOfType<SlappableFace>();
        }
    }

    private void OnEnable()
    {
        if (slappableFace != null)
        {
            slappableFace.Slapped += HandleSlapped;
        }
    }

    private void Start()
    {
        RefreshUi();
    }

    private void OnDisable()
    {
        if (slappableFace != null)
        {
            slappableFace.Slapped -= HandleSlapped;
        }
    }

    private void HandleSlapped()
    {
        score += 1;
        RefreshUi();
    }

    public void ResetScore()
    {
        score = 0;
        RefreshUi();
    }

    private void RefreshUi()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Slaps: {score}";
        }

        if (statusText != null)
        {
            statusText.text = score == 0 ? "Tap the face to start." : "Nice slap.";
        }
    }
}
