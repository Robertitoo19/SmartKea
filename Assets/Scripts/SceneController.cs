using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject hombre;
    [SerializeField] private GameObject mujer;
    public void Hombre()
    {
        hombre.SetActive(true);
        mujer.SetActive(false);
    }
    public void Mujer()
    {
        hombre.SetActive(false);
        mujer.SetActive(true);
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
}
