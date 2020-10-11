using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointController : MonoBehaviour
{
    public int score = 500;
    public Text scoreText;

    public Text ingameScore;
    
    public Text bestScoreText;
    // Start is called before the first frame update
    public void ShowScore(){
        score = Mathf.Max(0, score);
        int bestScore = PlayerPrefs.GetInt("best", 0);
        if(score > bestScore) {
            bestScore = score;
            PlayerPrefs.SetInt("best", bestScore);
        }
        scoreText.text = "" + score;
        bestScoreText.text = "" + bestScore;
    }

    public void ResetGame(){
        score = 500;
    }
    private void Update() {
        ingameScore.text = "" + score;
    }
}
