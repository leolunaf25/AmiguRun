using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameSpeed = 2f; // Velocidad inicial
    public float maxSpeed = 20f; 
    public float speedIncreaseRate = 1f; 
    public float timeToIncrease = 15f; 

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeToIncrease && gameSpeed < maxSpeed)
        {
            gameSpeed += speedIncreaseRate;
            elapsedTime = 0f;
        }
    }
}
