using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1); // при кнопке старт 
                                   // запускаем нужную нам сцену, в скобках индекс сцены
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
