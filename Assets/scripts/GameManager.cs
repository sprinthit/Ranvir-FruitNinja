using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text goldText;
     

    public int score;
    public int Gold;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        Gold = 0;
        goldText.text = Gold.ToString();
        score = 0;
        scoreText.text = score.ToString();

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

    }
        public void GoldScore()
        {
            if(score % 5 == 0)
            {
                Gold++;
                goldText.text = Gold.ToString();

            }
        }
   
    
}
