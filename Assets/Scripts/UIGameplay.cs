using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image livesBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score text
        scoreText.text = "Score: " + GameManager.instance.players[0].score;

        // Update the lives bar 
        //    Percentage -- current out of max    OR  current/max   
        livesBar.fillAmount = (float)GameManager.instance.players[0].lives / 
                                       (float)GameManager.instance.startLives;

    }
}
