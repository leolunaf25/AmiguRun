using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefabSegmento;
    public int poolSize = 10; // Número de objetos que deseas mantener en el pool
    private Queue<GameObject> pool;

    void Start()
    {
        pool = new Queue<GameObject>();

        // Inicializa el pool con segmentos inactivos
        for (int i = 0; i < poolSize; i++)
        {
            GameObject segment = Instantiate(prefabSegmento);
            segment.SetActive(false); // Mantén los objetos inactivos al principio
            pool.Enqueue(segment);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject segment = pool.Dequeue();
            segment.SetActive(true); // Activar el objeto cuando se usa
            return segment;
        }
        else
        {
            // Si no hay objetos disponibles, crea uno nuevo (opcional)
            GameObject segment = Instantiate(prefabSegmento);
            return segment;
        }
    }

    public void ReturnObject(GameObject segment)
    {
        segment.SetActive(false); // Desactivar y devolver el objeto al pool
        pool.Enqueue(segment);
    }
}
