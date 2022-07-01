
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public float highScore = 0;
    private TextMeshProUGUI text;
    public TextMeshProUGUI highScoreText;
    private const string saveHighScore = "Score";

    public void SaveScore()
    {
        PlayerPrefs.SetFloat(saveHighScore, highScore);
    }
        public void Awake()
    {
        highScore = PlayerPrefs.GetFloat(saveHighScore);//load
        publicHighScore();
        text = GetComponent<TextMeshProUGUI>();
        score = 0;       
    }

    public void ScoreUpdate(int add)
    {
        score += add;
        text.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            publicHighScore();
            SaveScore();
        }
    }
    public void publicHighScore()
    {
        highScoreText.text = "HIGH SCORE " + highScore;
    }

}
