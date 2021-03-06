﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource audioSource;
    public Canvas mainMenu;
    public Canvas questionsMenu;
    public Button btnStart;
    public Button btnNextQuestion;
    public Button btnBack;
    public Button btnDone;
    public Button btnQuit;
    public InputField tvQuestion;
    public InputField tvCorrectAnswer;
    public InputField tvAnswer2;
    public InputField tvAnswer3;
    public InputField tvAnswer4;
    public Text tvQuestionCount;
    public Text tvError;
    private int questionCount;
    // Start is called before the first frame update
    void Start()
    {
       QuizManager.questions = new List<Question>();
        questionCount = 1;
        questionsMenu.gameObject.SetActive(false);
        btnStart.onClick.AddListener(setUpQuestionsMenu);
        btnNextQuestion.onClick.AddListener(addQuestions);
        btnDone.onClick.AddListener(loadGame);
        btnQuit.onClick.AddListener(Application.Quit);
        btnBack.onClick.AddListener(loadMainMenu);
        // btnBack.onClick.AddListener(setUpMainMenu);
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        Graphic graphic = tvQuestion.GetComponent<InputField>().placeholder;
        ((Text)graphic).text = $"Question: {questionCount}";


    }

    void setUpQuestionsMenu() {
        questionsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    void addQuestions() {
      tvError.text = "";
      if(string.IsNullOrEmpty(tvQuestion.text)){
        tvError.text = "Please Enter a Question!";
      }
      else if(string.IsNullOrEmpty(tvCorrectAnswer.text)){
        tvError.text = "Please Set a Correct Answer!";
      }
      else if(string.IsNullOrEmpty(tvAnswer2.text) || string.IsNullOrEmpty(tvAnswer3.text) || string.IsNullOrEmpty(tvAnswer4.text)){
        tvError.text = "Please Enter The Rest of The answers!";
      }
      else{
        QuizManager.questions.Add(new Question(tvQuestion.text, tvCorrectAnswer.text, tvAnswer2.text, tvAnswer3.text, tvAnswer4.text));
            clearFields();
            questionCount++;
            tvQuestionCount.text = "Question Set: "+questionCount;
      }
    }

    void loadGame() {
        //QuizManager.questions.Add(new Question(tvQuestion.text, tvCorrectAnswer.text, tvAnswer2.text, tvAnswer3.text, tvAnswer4.text));
        //Debug.Log(tvQuestion.text);
      if(questionCount<=3){
        tvError.text = "Please Enter At Least 3 Question Sets!";

      }
      else{
        tvError.text = "";
        clearFields();
        audioSource.Stop();
        SceneManager.LoadScene("GamePlay");
      }
    }

    void clearFields() {
        tvQuestion.text = "";
        tvCorrectAnswer.text = "";
        tvAnswer2.text = "";
        tvAnswer3.text = "";
        tvAnswer4.text = "";

    }

    void loadMainMenu() {
        questionsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

}
