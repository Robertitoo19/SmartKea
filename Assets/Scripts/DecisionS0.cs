using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Decision System")]
public class DecisionS0 : ScriptableObject
{
    [TextArea] public string questionText;
    public DecisionOption[] options;
}

[System.Serializable]
public class DecisionOption
{
    public string optionText;
    public DecisionS0 nextNode;
}
