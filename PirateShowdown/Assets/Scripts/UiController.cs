using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public GameObject MenuPause;
    public GameObject DeadMenu;
    public static UiController Instace;
    
    private bool IsPaused;
    
    void Start()
    {
        Instace = this;
        MenuPause.SetActive(false);
        IsPaused = false;
        SwitchPause(IsPaused);
    }

    void Update(){
        KeyListener();
    }

    void KeyListener(){
        if (Input.GetKeyDown(KeyCode.P)){
            IsPaused = !IsPaused;
            SwitchPause(IsPaused);
        }
    }

    public void ReturnGame(){
        SwitchPause(false);
    }

    void SwitchPause(bool pauseState){
        if(pauseState){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1.0f;
        }
        MenuPause.SetActive(pauseState);
    }

    public void QuitGame(){
            Application.Quit();
    }

    public void MenuLoad(){
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel(){
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void MenuDead(){
        DeadMenu.SetActive(true);
    }
}
