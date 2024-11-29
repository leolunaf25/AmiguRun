using UnityEngine;

public class Segment : MonoBehaviour
{
    public ObjectPool objectPool;
    public float speed = 5.0f; // Velocidad de desplazamiento

void Update()
{
    // Mueve el segmento hacia la izquierda
    transform.Translate(Vector3.left * speed * Time.deltaTime);

    // Si el segmento sale de la pantalla, regresa al pool
    if (transform.position.x < -15.0f) 
    {
        // En lugar de destruir el objeto, lo devuelves al pool
        objectPool.ReturnObject(gameObject); // Reemplaza Destroy con ReturnObject
    }
}

}
