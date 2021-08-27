using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    private static MenuControl _instance;

    public static MenuControl Instance { get { return _instance; } }
    // Start is called before the first frame update


    [SerializeField]
    private GameObject pauseScreen; 

    [SerializeField]
    private GameObject gameOverScreen; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseScreen(); 
        }
    }

    public void TogglePauseScreen()
    {
        if (Time.timeScale != 0)
            Time.timeScale = 0;
        else
            Time.timeScale = 1; 

        pauseScreen.SetActive(!pauseScreen.activeInHierarchy);
    }

    public void DisplayGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); 
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
