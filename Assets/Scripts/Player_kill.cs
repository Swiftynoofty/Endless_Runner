using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_kill : MonoBehaviour
{


    public LevelManager theLevelManager;
    public playerControll controllPlayer;
    


    
    private ScoreManager scoreManager;

  
    


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            
            theLevelManager.RestartGame();
            
            
        }
    }

   
}