using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class PostProcessScript : MonoBehaviour
{
    public Volume postProcessVolume;
    public float minDistortion = -0.5f;
    public float maxDistortion = 0.5f;
    public float distortionSpeed = 1f;

    public float startContrast = 20f;
    public float endContrast = 50f;
    public float contrastDuration = 2f;

    private ColorAdjustments colorAdjustments;

    void Start()
    {
        postProcessVolume.profile.TryGet(out colorAdjustments);

        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = startContrast;
            StartCoroutine(IncreaseContrastOnce());
        }
    }

    IEnumerator IncreaseContrastOnce()
    {
        float elapsed = 0f;
        while (elapsed < contrastDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / contrastDuration);
            colorAdjustments.postExposure.value = Mathf.Lerp(startContrast, endContrast, t);
            yield return null;
        }
        colorAdjustments.postExposure.value = endContrast;
    }
}
