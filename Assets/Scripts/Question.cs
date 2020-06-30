using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{ 
    private string question="";
    private string[] answers = new string[4];
    private string correctAnswer = "";

    public Question(string newQuestion, string newAnswer1, string newAnswer2, string newAnswer3, string newAnswer4) {
        question = newQuestion;
        correctAnswer = newAnswer1;
        answers[0] = newAnswer1;
        answers[1] = newAnswer2;
        answers[2] = newAnswer3;
        answers[3] = newAnswer4;
        shuffleAnswers();

    }

    public string getCorrectAnswer() {
        return correctAnswer;
    }

    public string getQuestion()
    {
        return question;
    }

    public string getAnswer(int index)
    {
        return answers[index];
    }

    public void shuffleAnswers()
    {
        RandomizeArray.Randomize(answers);
    }


}
