using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class d_SplashScreen : MonoBehaviour
{
    [SerializeField] private Image logo;
    private int timer;

    void Start()
    {
        logo.GetComponent<CanvasRenderer>().SetAlpha(0);
    }

    private void Update()
    {
        timer++;
        fadeIn();
    }

    public void fadeIn()
    {
        logo.CrossFadeAlpha(1, 1, false);

        if(timer == 1000)
        {
            SceneManager.LoadScene(1);
        }
    }
}