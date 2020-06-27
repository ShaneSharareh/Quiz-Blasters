using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static bool resume = true;
    public static int questionCounter = 0;
    public static string correctAnswer = "";
    public Text livesText;
    public Text gameOverText;
    public Text questionText;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;
    //public Question question = new Question("What is bulgarian cheese", "Frutons", "crutons", "Mayonayse", "ChineseCheddar");
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = $"Lives: ${lives}";
        gameOverText.text = "";
      
    }

    // Update is called once per frame
    void Update()
    {
        if (questionCounter < QuizManager.questions.Capacity)
        {
            livesText.text = "Lives: " + lives;
            questionText.text =QuizManager.questions[questionCounter].getQuestion();
            answer1Text.text = QuizManager.questions[questionCounter].getAnswer(0);
            answer2Text.text = QuizManager.questions[questionCounter].getAnswer(1);
            answer3Text.text = QuizManager.questions[questionCounter].getAnswer(2);
            answer4Text.text = QuizManager.questions[questionCounter].getAnswer(3);
            correctAnswer = QuizManager.questions[questionCounter].getCorrectAnswer();
        }
        else {
            resume = false;
            gameOverText.text = "You Win";
            ;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            resume = true;
        }

        if (lives == 0) {
            gameOverText.text = "GAME OVER!";
        }
    }


    void setQuestions() {

    }
}
