using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private GameObject menuPanel;
    private GameObject creditsPanel;
    public Texture2D cursorHandTexture;
    private Texture2D defaultCursor;

    private void Start()
    {
        menuPanel = GameObject.Find("MainMenu");
        creditsPanel = GameObject.Find("CreditsPanel");
        creditsPanel.SetActive(false);
        defaultCursor = null;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Credits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
        SetCursorExit();
    }

    public void BackButton()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        SetCursorExit();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetCursorOver()
    {
        Cursor.SetCursor(cursorHandTexture, Vector2.zero, CursorMode.Auto);
    }

    public void SetCursorExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnDestroy()
    {
        SetCursorExit();
    }
}
