using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string lvlname;

    public void SceneLoad(){
        SceneManager.LoadScene(lvlname);
    }

    public void QuitGame(){
            Application.Quit();
    }
}
