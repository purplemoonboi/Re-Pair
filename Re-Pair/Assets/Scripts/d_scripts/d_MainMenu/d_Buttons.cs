using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class d_Buttons : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void activateMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}