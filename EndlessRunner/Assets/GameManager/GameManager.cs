using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton para facilitar el acceso
    public Transform playerTransform;  // Referencia al Transform del jugador
    public Vector3 respawnPosition;    // Posición inicial o de reinicio

    private void Awake()
    {
        // Configura el Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Configura la posición de respawn inicial
        respawnPosition = playerTransform.position;
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over! Reiniciando posición del jugador...");
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        // Reinicia la posición del jugador
        playerTransform.position = respawnPosition;
    }
}

