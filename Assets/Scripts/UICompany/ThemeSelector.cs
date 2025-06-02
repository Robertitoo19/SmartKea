using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class UITheme
{
    public string name;
    public Sprite logo;
    public Color backgroundColor;
    public Color textColor;
    public Color buttonColor;
}
public class ThemeSelector : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown themeDropdown;

    private void Start()
    {
        int savedIndex = PlayerPrefs.GetInt("SelectedThemeIndex", 0);
        themeDropdown.value = savedIndex;
        themeDropdown.onValueChanged.AddListener(OnThemeSelected);
    }

    private void OnThemeSelected(int index)
    {
        PlayerPrefs.SetInt("SelectedThemeIndex", index);
        PlayerPrefs.Save();
    }
}
