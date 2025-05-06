using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomizationManager : MonoBehaviour
{
    public static CharacterCustomizationManager Instance;

    [Header("Piel")]
    [SerializeField] private Renderer[] skinRenderer;
    [SerializeField] private Color[] skinColors;
    private int skinIndex = 0;

    [Header("Pelo")]
    [SerializeField] private Transform hairParent; 
    [SerializeField] private GameObject[] hairPrefabs;
    private int hairIndex = 0;
    private GameObject currentHair;

    [Header("Color Pelo")]
    [SerializeField] private Color[] hairColors;
    private int hairColorIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (skinRenderer != null)
        {
            for (int i = 0; i < skinRenderer.Length; i++)
            {
                if (skinRenderer[i] != null)
                {
                    skinRenderer[i].material = new Material(skinRenderer[i].material);
                }
            }
        }

        ApplySkinColor();
        ApplyHair();
    }
    public void ChangeSkinColor(int direction)
    {
        if (skinColors == null || skinColors.Length == 0)
            return;

        skinIndex = (skinIndex + direction + skinColors.Length) % skinColors.Length;
        ApplySkinColor();
    }
    private void ApplySkinColor()
    {
        if (skinRenderer == null || skinRenderer.Length == 0)
            return;

        foreach (Renderer rend in skinRenderer)
        {
            if (rend != null)
            {
                // Instancia el material para que no se modifique el original
                rend.material = new Material(rend.material);
                rend.material.color = skinColors[skinIndex];
            }
        }
    }
    public void ChangeHair(int direction)
    {
        if (hairPrefabs == null || hairPrefabs.Length == 0)
            return;

        hairIndex = (hairIndex + direction + hairPrefabs.Length) % hairPrefabs.Length;
        ApplyHair();
    }

    private void ApplyHair()
    {
        if (hairParent == null || hairPrefabs == null || hairPrefabs.Length == 0)
            return;

        if (currentHair != null)
            Destroy(currentHair);

        currentHair = Instantiate(hairPrefabs[hairIndex], hairParent);
        currentHair.transform.localPosition = Vector3.zero;
        currentHair.transform.localRotation = Quaternion.identity;
        currentHair.transform.localScale = Vector3.one;

        ApplyHairColor();
    }
    public void ChangeHairColor(int direction)
    {
        if(hairColors == null || hairColors.Length == 0 || currentHair == null)
        {
            return;
        }

        hairColorIndex = (hairColorIndex + direction + hairColors.Length) % hairColors.Length;
        ApplyHairColor();
    }

    private void ApplyHairColor()
    {
        Renderer hairRenderer = currentHair.GetComponentInChildren<Renderer>();
        if (hairRenderer != null)
        {
            hairRenderer.material.color = hairColors[hairColorIndex];
        }
    }

    public void SetCharacterReferences(Renderer[] newSkinRenderer, Transform newHairParent)
    {
        skinRenderer = newSkinRenderer;
        hairParent = newHairParent;

        ApplySkinColor();
        ApplyHair();
    }
}
