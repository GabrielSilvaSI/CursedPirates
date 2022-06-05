using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject MenuPause;
    
    private bool IsPaused;

    void Start()
    {
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
}
