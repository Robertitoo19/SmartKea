using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Decision System")]
public class DecisionSO : ScriptableObject
{
    [TextArea] public string questionText;
    public DecisionOption[] options;
}

[System.Serializable]
public class DecisionOption
{
    public string optionText;
    public DecisionSO nextNode;
    public string triggerID;
}
