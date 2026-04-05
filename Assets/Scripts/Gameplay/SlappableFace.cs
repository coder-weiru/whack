using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlappableFace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform faceVisual;
    [SerializeField] private Image slapFlash;
    [SerializeField] private AudioSource slapAudio;
    [SerializeField] private float slapScale = 1.08f;
    [SerializeField] private float slapDuration = 0.12f;

    private Coroutine slapRoutine;

    public event Action Slapped;

    private void Awake()
    {
        if (faceVisual == null)
        {
            faceVisual = transform as RectTransform;
        }

        if (slapFlash != null)
        {
            var color = slapFlash.color;
            color.a = 0f;
            slapFlash.color = color;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RegisterSlap();
    }

    public void RegisterSlap()
    {
        Slapped?.Invoke();

        if (slapAudio != null)
        {
            slapAudio.Play();
        }

        if (!gameObject.activeInHierarchy || faceVisual == null)
        {
            return;
        }

        if (slapRoutine != null)
        {
            StopCoroutine(slapRoutine);
        }

        slapRoutine = StartCoroutine(PlaySlapAnimation());
    }

    private IEnumerator PlaySlapAnimation()
    {
        Vector3 originalScale = faceVisual.localScale;
        Vector3 targetScale = originalScale * slapScale;
        float elapsed = 0f;

        while (elapsed < slapDuration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / slapDuration);
            float eased = 1f - Mathf.Pow(1f - progress, 3f);
            faceVisual.localScale = Vector3.LerpUnclamped(originalScale, targetScale, eased);
            SetFlashAlpha(Mathf.Lerp(0.35f, 0f, progress));
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < slapDuration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / slapDuration);
            faceVisual.localScale = Vector3.LerpUnclamped(targetScale, originalScale, progress);
            SetFlashAlpha(Mathf.Lerp(0.15f, 0f, progress));
            yield return null;
        }

        faceVisual.localScale = originalScale;
        SetFlashAlpha(0f);
        slapRoutine = null;
    }

    private void SetFlashAlpha(float alpha)
    {
        if (slapFlash == null)
        {
            return;
        }

        Color color = slapFlash.color;
        color.a = alpha;
        slapFlash.color = color;
    }
}
