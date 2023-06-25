using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject scaleMenuUI;
    public GameObject controlsMenuUI;
    public Camera mainCamera;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OpenOptionsMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void OpenScaleMenu()
    {
        optionsMenuUI.SetActive(false);
        scaleMenuUI.SetActive(true);
    }

    public void OpenControlsMenu()
    {
        optionsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        scaleMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }
    public void ClosescaleMenu()
    {
        scaleMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void SetCameraScale(float scale)
    {
        mainCamera.orthographicSize = scale;
    }
}
