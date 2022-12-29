using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadScene(string _name)
    {
        SceneManager.LoadScene(_name);
    }

    public void QuiGame()
    {
        Application.Quit();
    }
}
