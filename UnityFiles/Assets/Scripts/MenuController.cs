using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    public GameObject ControlCanva;
    public GameObject MenuCanva;
    public GameObject InfoCanva;

    public string lvlname;
    
    void Start()
    {
        Instance = this;
    }

    public void LoadLevel(){
        SceneManager.LoadScene(lvlname);
    }

    public void ControllerInfo(){
        ControlCanva.SetActive(true);
        MenuCanva.SetActive(false);
        InfoCanva.SetActive(false);
    }

    public void MenuSwitch(){
        MenuCanva.SetActive(true);
        ControlCanva.SetActive(false);
        InfoCanva.SetActive(false);
    }

    public void InfoSwitch(){
        InfoCanva.SetActive(true);
        ControlCanva.SetActive(false);
        MenuCanva.SetActive(false);
    }

    public void QuitGame(){
            Application.Quit();
    }
}
