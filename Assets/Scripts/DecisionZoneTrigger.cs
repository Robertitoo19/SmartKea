using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionZoneTrigger : MonoBehaviour
{
    public DecisionS0 startingNode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<DecisionManager>().StartDecision(startingNode);
        }
    }
}
