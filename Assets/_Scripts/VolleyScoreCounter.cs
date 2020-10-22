using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolleyScoreCounter : MonoBehaviour
{
    public int enemyScore = 0, playerScore = 0;

    public Text enemyText, playerText;
    bool psadd = true;
    bool esadd = true;
    // Start is called before the first frame update
    float psstartTime, esstartTime;

    private void Start()
    {
        psstartTime = Time.time;
        psstartTime = Time.time;
    }
    public void AddPlayerScore()
    {
        if (Time.time>= psstartTime + 0.1)
        {
            playerScore++;
            Debug.Log($"ps - {playerScore.ToString()} {enemyScore.ToString()}");
            playerText.text = playerScore.ToString();
            psstartTime = Time.time;
        }
    }
    public void AddEnemyScore()
    {
        if (Time.time >= esstartTime + 0.1)
        {
            enemyScore++;
            Debug.Log($"es - {playerScore.ToString()} {enemyScore.ToString()}");
            enemyText.text = enemyScore.ToString();
            esstartTime = Time.time;
        }
    }


   
}


