using UnityEngine;

public class Platform : MonoBehaviour
{
    public void Initialize(float minWidth, float maxWidth, float xOffset)
    {
        // Configura el tamaño de la plataforma
        float width = Random.Range(minWidth, maxWidth);
        transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);

        // Posiciona la plataforma en el eje X
        transform.position += new Vector3(xOffset, 0, 0);
    }
}
