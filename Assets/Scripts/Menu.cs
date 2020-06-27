using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas questionsMenu;
    public Button btnStart;
    public Button btnNextQuestion;
    public Button btnBack;
    public Button btnDone;
    public Text tvQuestion;
    public Text tvCorrectAnswer;
    public Text tvAnswer2;
    public Text tvAnswer3;
    public Text tvAnswer4;
    public List<int> questions;
    // Start is called before the first frame update
    void Start()
    {
        questions = new List<int>();
        questionsMenu.gameObject.SetActive(false);
        btnStart.onClick.AddListener(setUpQuestionsMenu); ;
        btnNextQuestion.onClick.AddListener(addQuestions);
        btnDone.onClick.AddListener(loadGame);
       // btnBack.onClick.AddListener(setUpMainMenu);


    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void setUpQuestionsMenu() {
        questionsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    void addQuestions() {
        questions.Add(3);//new Question(tvQuestion.text, tvCorrectAnswer.text, tvAnswer2.text, tvAnswer3.text, tvAnswer4.text));
    }

    void loadGame() {
        questions.Add(4);//new Question(tvQuestion.text, tvCorrectAnswer.text, tvAnswer2.text, tvAnswer3.text, tvAnswer4.text));
        //Debug.Log(tvQuestion.text);
        SceneManager.LoadScene("GamePlay");
    }

}
