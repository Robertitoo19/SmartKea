using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public Renderer[] skinRenderer;
    public Transform hairParent;
    void Start()
    {
        CharacterCustomizationManager.Instance.SetCharacterReferences(skinRenderer, hairParent);
    }
}
