using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{

    public text scoreText;
    public text hiScoreText;
    public float scoreCount;
    public float hiScoreCount;
    public float pointPerSecond;
    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreCount;
        hiScoreText.text = "High Score: " + hiScoreCount;
    }
}
