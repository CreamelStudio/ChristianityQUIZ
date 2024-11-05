using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class QuizLoader : MonoBehaviour
{
    public List quizlist;
    public int tempInt;

    public TextMeshProUGUI tmpQuizText;

    public TextMeshProUGUI sel5TB1;
    public TextMeshProUGUI sel5TB2;
    public TextMeshProUGUI sel5TB3;
    public TextMeshProUGUI sel5TB4;
    public TextMeshProUGUI sel5TB5;

    public TextMeshProUGUI inputF;

    public GameObject[] resultPannel;

    public GameObject right;
    public GameObject fail;

    public void Start()
    {
        tempInt = 0;
        LoadNextQuiz();
    }

    public void LoadNextQuiz()
    {
        tempInt = UnityEngine.Random.Range(0, quizlist.quiz.Length);
        tmpQuizText.text = quizlist.quiz[tempInt].QuizText;
        resultPannel[quizlist.quiz[tempInt].quizType].SetActive(true);

        if (quizlist.quiz[tempInt].quizType == 1)
        {
            sel5TB1.text = quizlist.quiz[tempInt].sel5Problem1;
            sel5TB2.text = quizlist.quiz[tempInt].sel5Problem2;
            sel5TB3.text = quizlist.quiz[tempInt].sel5Problem3;
            sel5TB4.text = quizlist.quiz[tempInt].sel5Problem4;
            sel5TB5.text = quizlist.quiz[tempInt].sel5Problem5;
        }

    }

    public void ResultOX(int value)
    {
        if(value == quizlist.quiz[tempInt].oxResult) EnswerChec(1);
        else EnswerChec(0);
    }

    public void ResultSel5(int value)
    {
        if(value == quizlist.quiz[tempInt].sel5Result) EnswerChec(1);
        else EnswerChec(0);
    }

    public void ResultTexting()
    {
        if (string.Equals(inputF.text.Trim(), quizlist.quiz[tempInt].textingResult.Trim(), StringComparison.OrdinalIgnoreCase)) EnswerChec(1);
        else EnswerChec(0);
        Debug.Log(string.Equals(inputF.text.Trim(), quizlist.quiz[tempInt].textingResult.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public void EnswerChec(int value)
    {
        if (value == 1) right.SetActive(true);
        else fail.SetActive(true);

        StartCoroutine(initQuiz());
    }

    IEnumerator initQuiz()
    {
        yield return new WaitForSeconds(0.5f);
        right.SetActive(false);
        fail.SetActive(false);
        for(int i = 0; i < resultPannel.Length; i++) resultPannel[i].SetActive(false);
        LoadNextQuiz();
    }
}
