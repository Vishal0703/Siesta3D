using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolleyScoreCounter : MonoBehaviour
{
    public int enemyScore, playerScore;

    public Text enemyText, playerText;
    // Start is called before the first frame update
    public void AddPlayerScore()
    {
        playerScore++;
        playerText.text = playerScore.ToString();
    }
    public void AddEnemyScore()
    {
        enemyScore++;
        enemyText.text = enemyScore.ToString();
    }

}
