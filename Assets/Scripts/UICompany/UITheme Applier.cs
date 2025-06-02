using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIThemeApplier : MonoBehaviour
{
    [SerializeField] private UITheme[] themes;

    [Header("UI Elements")]
    [SerializeField] private Image logoImage;
    [SerializeField] private Image[] backgroundImages;
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private Button[] buttons;

    private void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedThemeIndex", 0);
        ApplyTheme(index);
    }

    private void ApplyTheme(int index)
    {
        if (index < 0 || index >= themes.Length) return;

        UITheme theme = themes[index];

        if (logoImage != null && theme.logo != null)
            logoImage.sprite = theme.logo;

        foreach (var img in backgroundImages)
            if (img != null) img.color = theme.backgroundColor;

        foreach (var txt in texts)
            if (txt != null) txt.color = theme.textColor;

        foreach (var btn in buttons)
            if (btn != null) btn.image.color = theme.buttonColor;
    }
}
