using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cevap : MonoBehaviour
{

    public bool isCorrect = false;
    private Quiz_Manager quiz;
    public GameObject QuizPanel;
    public PlayerData playerData; // Unity Editor'da atayabileceğiniz ScriptableObject

    public void Start()
    {
        quiz = QuizPanel.GetComponent<Quiz_Manager>();
    }

    public void Answer()
    {

        if (isCorrect)
        {
            quiz.Right();
        }
        else
        {
            quiz.Wrong();
        }

    }

}
