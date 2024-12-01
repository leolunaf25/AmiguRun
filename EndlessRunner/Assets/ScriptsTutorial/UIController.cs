using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    Player player;
    TextMeshProUGUI distanceText;

    GameObject results;
    TextMeshProUGUI finalDistanceText;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<TextMeshProUGUI>();

        results = GameObject.Find("Results");
        finalDistanceText = GameObject.Find("FinalDistanceText").GetComponent<TextMeshProUGUI>();
        results.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";
        
        if (player.isDead)
        {
            results.SetActive(true);
            finalDistanceText.text = distance + " m";
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
