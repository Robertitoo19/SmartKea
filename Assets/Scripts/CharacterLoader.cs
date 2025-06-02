using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private Renderer[] skinRenderer;
    [SerializeField] private Renderer[] shirtRenderer;
    [SerializeField] private Renderer[] tieRenderer;
    [SerializeField] private Renderer[] jacketRenderer;
    [SerializeField] private Renderer[] pantsRenderer;
    [SerializeField] private Renderer[] shoesRenderer;

    [SerializeField] private Transform hairParent;
    void Start()
    {
        CharacterCustomizationManager.Instance.SetCharacterReferences(skinRenderer, hairParent, shirtRenderer, tieRenderer, jacketRenderer, pantsRenderer, shoesRenderer);
    }
}
