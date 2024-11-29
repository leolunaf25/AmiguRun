using UnityEngine;
using System.Collections.Generic;

public class SegmentController : MonoBehaviour
{
    public ObjectPool objectPool; // Referencia al pool de objetos
    public Transform puntoInicio;
    public int cantidadSegmentos = 2;
    public float distanciaEntreSegmentos = 15.0f;

    private Queue<GameObject> segmentosActivos = new Queue<GameObject>();
    private float posicionSiguiente;

    void Start()
    {
        posicionSiguiente = puntoInicio.position.x;

        // Inicializa los segmentos utilizando el Object Pool
        for (int i = 0; i < cantidadSegmentos; i++)
        {
            CrearSegmento();
        }
    }
    
void Update()
{
    if (segmentosActivos.Count > 0)
    {
        GameObject primerSegmento = segmentosActivos.Peek();
        if (primerSegmento.transform.position.x < -15.0f) // Ajusta según la posición límite
        {
            objectPool.ReturnObject(primerSegmento); // Regresar el objeto al pool
            segmentosActivos.Dequeue();

            // No incrementes la distancia al devolver el segmento
            CrearSegmento();
        }
    }
}

    private void CrearSegmento()
    {
        GameObject nuevoSegmento = objectPool.GetObject(); // Obtener un segmento del pool
        nuevoSegmento.transform.position = new Vector3(posicionSiguiente, puntoInicio.position.y, 0);
        segmentosActivos.Enqueue(nuevoSegmento);
        posicionSiguiente += distanciaEntreSegmentos;
    }
}
