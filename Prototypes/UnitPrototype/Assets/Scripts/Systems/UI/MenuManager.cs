using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject GameHUD;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
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
        ToggleMenu(PauseMenu);
        ToggleMenu(GameHUD);

        if (Time.timeScale > 0) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void GameOver()
    {
        ToggleMenu(GameOverMenu);
        ToggleMenu(GameHUD);

        Time.timeScale = 0;
    }
}
