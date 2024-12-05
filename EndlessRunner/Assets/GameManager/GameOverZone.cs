using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra en la zona es el jugador
        if (collision.CompareTag("Player"))
        {
            // Llama al método para manejar el Game Over
            GameManager.Instance.TriggerGameOver();
        }
    }
}
