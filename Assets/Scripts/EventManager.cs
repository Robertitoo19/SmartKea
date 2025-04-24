using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event Action<string> OnQuestionAsked;
    public event Action<string[]> OnOptionsOffered;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void RaiseQuestion(string question)
    {
        OnQuestionAsked?.Invoke(question);
    }

    public void RaiseOptions(string[] options)
    {
        OnOptionsOffered?.Invoke(options);
    }
}
