using UnityEngine;

public class TransformAnimation : MonoBehaviour
{
     static float minScale = 0.75f;
     static float minScale2 = 0.85f;
     static float maxScale = .95f;
     static float maxScale2 = 1.1f;

    [SerializeField] float scaleSpeed = 1f;

    private Vector3 targetScale;

    void Start()
    {
        float scaleSpeed = Random.Range(.05f, 1.2f);
        float randomScale = Random.Range(minScale, minScale2);
        float randomScale2 = Random.Range(maxScale, maxScale2);
        SetNewTargetScale();
    }

    void Update()
    {


        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);

        if (Vector3.Distance(transform.localScale, targetScale) < 0.02f)
        {
            SetNewTargetScale();
        }
    }

    void SetNewTargetScale()
    {
        float randomScale = Random.Range(minScale, minScale2);
        float randomScale2 = Random.Range(maxScale, maxScale2);
        float s = Random.Range(randomScale, randomScale2);
        targetScale = new Vector3(s, transform.localScale.y, transform.localScale.z);
    }
}
