using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private Button[] optionButtons;

    private void OnEnable()
    {
        EventManager.Instance.OnQuestionAsked += ShowUIAndSetQuestion;
        EventManager.Instance.OnOptionsOffered += UpdateOptions;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnQuestionAsked -= ShowUIAndSetQuestion;
        EventManager.Instance.OnOptionsOffered -= UpdateOptions;
    }

    void ShowUIAndSetQuestion(string question)
    {
        canvas.SetActive(true);
        questionText.text = question;
        Time.timeScale = 0f;
    }

    void UpdateOptions(string[] options)
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < options.Length)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMP_Text>().text = options[i];

                int index = i;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() =>
                {
                    Time.timeScale = 1f;
                    canvas.SetActive(false);
                    FindObjectOfType<DecisionManager>().SelectOption(index);
                });
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
