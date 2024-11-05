using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class List : ScriptableObject
{
    public QuizList[] quiz;

    [System.Serializable]
    public struct QuizList
    {
        [Header("OX : 0번 객관식 : 1번 주관식 2번")]
        public int quizType;
        public string QuizText;
        public int oxResult;
        public string sel5Problem1;
        public string sel5Problem2;
        public string sel5Problem3;
        public string sel5Problem4;
        public string sel5Problem5;
        public int sel5Result;
        public string textingResult;


    }
    
}
