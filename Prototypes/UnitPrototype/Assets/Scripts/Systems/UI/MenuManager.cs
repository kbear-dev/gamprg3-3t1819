using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool isPaused;

    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject GameHUD;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void ToggleMenu(GameObject menu)
    {
        menu.SetActive(!menu.activeInHierarchy);
    }

    public void PauseGame()
    {
        if (Time.timeScale > 0)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }

        ToggleMenu(PauseMenu);
        ToggleMenu(GameHUD);     
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        isPaused = true;
        ToggleMenu(GameOverMenu);
        ToggleMenu(GameHUD);
    }
}
