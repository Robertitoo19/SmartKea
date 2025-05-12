using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UITheme
{
    public string name;
    public Sprite logo;
    public Color backgroundColor;
    public Color textColor;
    public Color buttonColor;
}
public class UIDropdownSwitcher : MonoBehaviour
{
    [Header("Dropdown")]
    [SerializeField] TMP_Dropdown themeDropdown;

    [Header("Elementos a cambiar")]
    [SerializeField] private Image logoImage;
    [SerializeField] private Image[] backgroundImages;
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private Button[] buttons;

    [Header("Temas")]
    [SerializeField] private UITheme[] themes;

    private void Start()
    {
        themeDropdown.onValueChanged.AddListener(OnThemeChanged);
        ApplyTheme(themeDropdown.value); // aplica el tema inicial
    }

    private void OnThemeChanged(int index)
    {
        ApplyTheme(index);
    }

    private void ApplyTheme(int index)
    {
        if (index < 0 || index >= themes.Length) return;

        UITheme theme = themes[index];

        // Cambiar logo
        if (logoImage != null && theme.logo != null)
            logoImage.sprite = theme.logo;

        // Cambiar fondo
        foreach (var img in backgroundImages)
        {
            if (img != null)
                img.color = theme.backgroundColor;
        }

        // Cambiar texto
        foreach (var txt in texts)
        {
            if (txt != null)
                txt.color = theme.textColor;
        }

        // Cambiar botones
        foreach (var btn in buttons)
        {
            if (btn != null)
                btn.image.color = theme.buttonColor;
        }
    }
}
