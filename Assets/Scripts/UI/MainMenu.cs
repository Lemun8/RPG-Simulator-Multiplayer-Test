using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject menuObj, settingsObj, controlsObj;
    public string SceneName;
    public AudioSource onClick;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void playGame()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void multiPlay()
    {
        SceneManager.LoadScene("Loading");
    }
    public void SettingsMenu()
    {
        menuObj.SetActive(false);
        settingsObj.SetActive(true);
        onClick.Play();
    }
    public void ControlsMenu()
    {
        menuObj.SetActive(false);
        controlsObj.SetActive(true);
        onClick.Play();
    }
    public void quitGame()
    {
        Debug.Log("This will quit the game, only works in actual build, not in Unity editor.");
        Application.Quit();
        onClick.Play();
    }
    public void backToMenu()
    {
        settingsObj.SetActive(false);
        controlsObj.SetActive(false);
        menuObj.SetActive(true);
        onClick.Play();
    }
}
