using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Player player;
    Text distanceText;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";
        
    }
}
