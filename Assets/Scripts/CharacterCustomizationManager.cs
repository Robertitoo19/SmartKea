using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomizationManager : MonoBehaviour
{
    public static CharacterCustomizationManager Instance;

    [Header("Piel")]
    public Renderer skinRenderer;
    public Color[] skinColors;
    private int skinIndex = 0;

    [Header("Pelo")]
    public Transform hairParent; 
    public GameObject[] hairPrefabs;
    private int hairIndex = 0;
    private GameObject currentHair;

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
        if (skinRenderer != null)
        {
            skinRenderer.material.color = skinColors[skinIndex];
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
    }
    public void SetCharacterReferences(Renderer newSkinRenderer, Transform newHairParent)
    {
        skinRenderer = newSkinRenderer;
        hairParent = newHairParent;

        ApplySkinColor();
        ApplyHair();
    }
}
