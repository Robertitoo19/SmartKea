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
    [SerializeField] private TMP_InputField themeCodeInput;
    [SerializeField] private UITheme[] themes;

    public void OnCodeSubmitted()
    {
        string inputCode = themeCodeInput.text.Trim().ToLower(); // limpieza básica

        int index = FindThemeIndexByCode(inputCode);
        if (index != -1)
        {
            PlayerPrefs.SetInt("SelectedThemeIndex", index);
            PlayerPrefs.Save();
            Debug.Log($"Código válido. Tema guardado: {themes[index].name}");
        }
        else
        {
            Debug.LogWarning("Código de tema no válido.");
            // Aquí podrías mostrar un mensaje en pantalla
        }
    }

    private int FindThemeIndexByCode(string code)
    {
        for (int i = 0; i < themes.Length; i++)
        {
            if (themes[i].name.ToLower() == code)
                return i;
        }
        return -1;
    }
}
