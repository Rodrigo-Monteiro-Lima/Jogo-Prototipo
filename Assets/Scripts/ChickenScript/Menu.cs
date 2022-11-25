using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    
    public void Play()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Options()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("saiu do jogo");
        Application.Quit();
    }
}