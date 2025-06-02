using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject genero;
    [SerializeField] private GameObject selector;
    public void Selector()
    {
        genero.SetActive(false);
        selector.SetActive(true);
    }
    public void Genero()
    {
        genero.SetActive(true);
        selector.SetActive(false);
    }
    public void EscenaHombre()
    {
        SceneManager.LoadScene(3);
    }
    public void EscenaMujer()
    {
        SceneManager.LoadScene(4);
    }
    public void PersoHombre()
    {
        SceneManager.LoadScene(1);
    }
    public void PersoMujer()
    {
        SceneManager.LoadScene(2);
    }
}
