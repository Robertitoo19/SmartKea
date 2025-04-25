using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionZoneTrigger : MonoBehaviour
{
    public DecisionSO startingNode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<DecisionManager>().StartDecision(startingNode);
            gameObject.SetActive(false);
        }
    }
}
