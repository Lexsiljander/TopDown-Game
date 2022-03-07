using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    public Text text;
    public Text highScore;
    public int score;

    public int highscore;
    
    
    // Start is called before the first frame update
    void Start()
    {
      

        highscore = PlayerPrefs.GetInt("highscore", 0);
        highScore.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void ChangeScore(int scoreValue)
    {
        score += scoreValue;
        text.text = "Score" + "X" + score.ToString();

        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           PlayerPrefs.DeleteKey("highscore");

        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
