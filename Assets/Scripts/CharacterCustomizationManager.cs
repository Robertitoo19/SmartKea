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
    private int skinColorIndex = 0;

    [Header("Pelo")]
    [SerializeField] private Transform hairParent; 
    [SerializeField] private GameObject[] hairPrefabs;
    private int hairIndex = 0;
    private GameObject currentHair;

    [Header("Color Pelo")]
    [SerializeField] private Color[] hairColors;
    private int hairColorIndex = 0;

    [Header("Chaqueta")]
    [SerializeField] private Renderer[] jacketRenderer;
    [SerializeField] private Color[] jacketColors;
    private int jacketColorIndex = 0;

    [Header("Pantalon")]
    [SerializeField] private Renderer[] pantsRenderer;
    [SerializeField] private Color[] pantsColors;
    private int pantsColorIndex = 0;

    [Header("Zapatos")]
    [SerializeField] private Renderer[] shoesRenderer;
    [SerializeField] private Color[] shoesColors;
    private int shoesColorIndex = 0;
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
        ApplyJacketColor();
        ApplyPantsColor();
        ApplyShoesColor();
        ApplyHair();
    }
    public void ChangeSkinColor(int direction)
    {
        if (skinColors == null || skinColors.Length == 0)
            return;

        skinColorIndex = (skinColorIndex + direction + skinColors.Length) % skinColors.Length;
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
                rend.material.color = skinColors[skinColorIndex];
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

    public void ChangeJacketColor(int direction)
    {
        if (jacketColors == null || jacketColors.Length == 0)
            return;

        jacketColorIndex = (jacketColorIndex + direction + jacketColors.Length) % jacketColors.Length;
        ApplyJacketColor();
    }

    private void ApplyJacketColor()
    {
        foreach (Renderer rend in jacketRenderer)
        {
            if (rend != null)
            {
                rend.material = new Material(rend.material);
                rend.material.color = jacketColors[jacketColorIndex];
            }
        }
    }

    public void ChangePantsColor(int direction)
    {
        if (pantsColors == null || pantsColors.Length == 0)
            return;

        pantsColorIndex = (pantsColorIndex + direction + pantsColors.Length) % pantsColors.Length;
        ApplyPantsColor();
    }

    private void ApplyPantsColor()
    {
        foreach (Renderer rend in pantsRenderer)
        {
            if (rend != null)
            {
                rend.material = new Material(rend.material);
                rend.material.color = pantsColors[pantsColorIndex];
            }
        }
    }

    public void ChangeShoesColor(int direction)
    {
        if (shoesColors == null || shoesColors.Length == 0)
            return;

        shoesColorIndex = (shoesColorIndex + direction + shoesColors.Length) % shoesColors.Length;
        ApplyShoesColor();
    }

    private void ApplyShoesColor()
    {
        foreach (Renderer rend in shoesRenderer)
        {
            if (rend != null)
            {
                rend.material = new Material(rend.material);
                rend.material.color = shoesColors[shoesColorIndex];
            }
        }
    }
    public void SetCharacterReferences(Renderer[] newSkin, Transform newHairParent, Renderer[] newJacket, Renderer[] newPants, Renderer[] newShoes)
    {
        skinRenderer = newSkin;
        jacketRenderer = newJacket;
        pantsRenderer = newPants;
        shoesRenderer = newShoes;

        hairParent = newHairParent;

        ApplySkinColor();
        ApplyJacketColor();
        ApplyPantsColor();
        ApplyShoesColor();
        ApplyHair();
    }
}
