using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static bool resume = true;
    public static int questionCounter = 0;
    public static string correctAnswer = "";
    public Text livesText;
    public Text enemyLivesText;
    public Text gameOverText;
    public Text questionText;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;
    public Canvas finishMenu;
    public Canvas gameOverMenu;
    public Canvas pauseMenu;
    public Button btnRestart;
    public Button btnQuitPause;
    public Button btnQuitGameOver;
    public Button btnContinue;
    public AudioSource loseAudio;
    public AudioSource winAudio;
  

    //public Question question = new Question("What is bulgarian cheese", "Frutons", "crutons", "Mayonayse", "ChineseCheddar");
    // Start is called before the first frame update
    void Start()
    {
        resume = true;
        //btnRestart.gameObject.SetActive(false);
        //btnBack.gameObject.SetActive(false);
        //btnContinue.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
        livesText.text = $"Lives: ${lives}";
        enemyLivesText.text = $"Invaders: {QuizManager.questions.Count - questionCounter}";
        gameOverText.text = "";
        btnRestart.onClick.AddListener(restartGame);
        btnQuitPause.onClick.AddListener(loadMenu);
        btnQuitGameOver.onClick.AddListener(loadMenu);
        btnContinue.onClick.AddListener(resumeGameplay);



    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives;
        enemyLivesText.text = $"Invaders: {QuizManager.questions.Count - questionCounter}";


        if (lives <1)
        {

            if (!loseAudio.isPlaying)
            {
                loseAudio.Play();
            }
            loadGameOverMenu(true,"GAME OVER!");
            //Destroy(GameObject.Find("Player").gameObject.transform);
        }

        if (Input.GetKey("escape") && resume)
        {
            loadPause(true);
            resume = false;

        }




            if (questionCounter < QuizManager.questions.Count)
        {
            questionText.text =QuizManager.questions[questionCounter].getQuestion();
            answer1Text.text = QuizManager.questions[questionCounter].getAnswer(0);
            answer2Text.text = QuizManager.questions[questionCounter].getAnswer(1);
            answer3Text.text = QuizManager.questions[questionCounter].getAnswer(2);
            answer4Text.text = QuizManager.questions[questionCounter].getAnswer(3);
            correctAnswer = QuizManager.questions[questionCounter].getCorrectAnswer();
        }
        else {
            if (!winAudio.isPlaying)
            {
                winAudio.Play();
            }
            resume = false;
            loadGameOverMenu(true,"YOU WIN!");
            Destroy(GameObject.Find("Enemy1").transform.parent.gameObject);
            ;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            resume = true;
        }


    }


    void setQuestions() {

    }

    public static void resetEnemies()
    {
        GameObject.Find("Enemy1").transform.position = (new Vector3(-2.61F, 2.93F, 164.5656F));
        GameObject.Find("Enemy2").transform.position = (new Vector3(2.64F, 2.93F, 164.5656F));
        GameObject.Find("Enemy3").transform.position = (new Vector3(-5.01F, 0.21F, 164.5656F));
        GameObject.Find("Enemy4").transform.position = (new Vector3(5.15F, 0.21F, 164.5656F));
        GameObject.Find("Enemy5").transform.position = (new Vector3(0.1F, 1.87F, 164.5656F));
    }

    public void restartGame() {
        questionCounter = 0;
        lives = 3;
        resume = true;
        SceneManager.LoadScene("GamePlay");

    }

    public void loadMenu() {
      SceneManager.LoadScene("Menu");

    }

    public void loadPause(bool status) {
        pauseMenu.gameObject.SetActive(status);

      }


    private void resumeGameplay() {
        resume = true;
        loadPause(false);
    }
    public bool isPaused(){
      return pauseMenu.gameObject.activeSelf;
    }

    public void loadGameOverMenu(bool status, string statusMessage){
      gameOverMenu.gameObject.SetActive(status);
      gameOverText.text = statusMessage;


    }
}
