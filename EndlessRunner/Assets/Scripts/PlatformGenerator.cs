using UnityEngine;

public class PlatfomGenerator : MonoBehaviour
{
    public Transform[] plataformas; // Asigna las plataformas en el inspector
    public float minHeight = 0f;
    public float maxHeight = 5f;
    public float minHeightDifference = 1.0f;
    public float maxHeightDifference = 3.0f;

    void Start()
    {
        float previousHeight = Random.Range(minHeight, maxHeight);

        foreach (Transform plataforma in plataformas)
        {
            float newHeight = Mathf.Clamp(
                previousHeight + Random.Range(minHeightDifference, maxHeightDifference) * (Random.value > 0.5f ? 1 : -1),
                minHeight,
                maxHeight
            );

            plataforma.localPosition = new Vector3(plataforma.localPosition.x, newHeight, plataforma.localPosition.z);
            previousHeight = newHeight;
        }
    }
}
