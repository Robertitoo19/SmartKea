using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [System.Serializable]
    public class TriggerEntry
    {
        public string triggerID;
        public GameObject triggerObject;
    }

    public List<TriggerEntry> triggerList;

    public void ActivateTrigger(string id)
    {
        foreach (var entry in triggerList)
        {
            if (entry.triggerID == id && entry.triggerObject != null)
            {
                entry.triggerObject.SetActive(true);
                break;
            }
        }
    }
}
