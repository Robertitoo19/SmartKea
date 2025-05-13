using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
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
