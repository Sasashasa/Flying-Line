using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Характреристики")]
    [SerializeField] private float duration = 0.15f;
    [SerializeField] private float magnitude = 0.2f;


    public void ShakeCamera() 
    {
        StartCoroutine(Shake());
    }


    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z); 
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
