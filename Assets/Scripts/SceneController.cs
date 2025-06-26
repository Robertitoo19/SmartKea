using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject hombre;
    [SerializeField] private GameObject mujer;
    [SerializeField] private GameObject botonHombre;
    [SerializeField] private GameObject botonMujer;
    [SerializeField] private GameObject Ocuiltar;
    public void Hombre()
    {
        botonHombre.SetActive(true);
        botonMujer.SetActive(false);
        hombre.SetActive(true);
        mujer.SetActive(false);
    }
    public void Mujer()
    {
        botonHombre.SetActive(false);
        botonMujer.SetActive(true);
        hombre.SetActive(false);
        mujer.SetActive(true);
    }
    public void Ocultar()
    {
        Ocuiltar.SetActive(false);
    }
    public void EscenaHombre()
    {
        SceneManager.LoadScene(2);
    }
    public void EscenaMujer()
    {
        SceneManager.LoadScene(3);
    }
    public void PersoHombre()
    {
        SceneManager.LoadScene(1);
    }
    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
