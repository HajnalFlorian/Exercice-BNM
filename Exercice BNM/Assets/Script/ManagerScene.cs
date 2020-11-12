using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScene : MonoBehaviour
{
    public void Exercice1()
    {
        SceneManager.LoadScene("Exercice1");
    }

    public void Exercice2()
    {
        SceneManager.LoadScene("Exercice2_bis");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
