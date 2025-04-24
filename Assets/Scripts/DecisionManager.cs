using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DecisionManager : MonoBehaviour
{
    private DecisionS0 currentNode;

    public void StartDecision(DecisionS0 startNode)
    {
        currentNode = startNode;
        ShowCurrentNode();
    }

    public void SelectOption(int index)
    {
        if (index < 0 || index >= currentNode.options.Length) return;

        currentNode = currentNode.options[index].nextNode;

        if (currentNode != null)
        {
            ShowCurrentNode();
        }
    }

    private void ShowCurrentNode()
    {
        EventManager.Instance.RaiseQuestion(currentNode.questionText);

        string[] optionTexts = new string[currentNode.options.Length];
        for (int i = 0; i < optionTexts.Length; i++)
        {
            optionTexts[i] = currentNode.options[i].optionText;
        }

        EventManager.Instance.RaiseOptions(optionTexts);
    }
}
