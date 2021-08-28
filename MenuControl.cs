using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuControl : MonoBehaviour
{
    private static MenuControl _instance;

    public static MenuControl Instance { get { return _instance; } }
    // Start is called before the first frame update


    [SerializeField]
    private GameObject pauseScreen; 

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private TextMeshProUGUI gameOverText; 

    void Start()
    {
        if (_instance == null || _instance != this)
            _instance = this; 

        if (Time.timeScale != 1)
            Time.timeScale = 1; 
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
        Time.timeScale = 0;
        gameOverText.text = "Game Over...";
        gameOverScreen.SetActive(true);
    }

    public void DispalyWinScreen()
    {
        Time.timeScale = 0;

        gameOverText.text = "You Win!";
        gameOverScreen.SetActive(true); 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); 
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
