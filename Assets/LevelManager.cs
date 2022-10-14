using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private ScoreManager theScoreManager;
    public playerControll thePlayer;
    private Vector3 playerStartPos;


    void Start()
    {
        playerStartPos = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }


    public void RestartGame()
    {
        StartCoroutine ("RestartGameCo");
    }


    public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false; 
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPos;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        thePlayer.canDash = true;
        
    }

}
