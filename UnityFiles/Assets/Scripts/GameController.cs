using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject[] CharsList;

    private int _cont;
    private GameController SwitchController;

    void Start() {
        SwitchController = GetComponent<GameController>();
        Instance = this;
        _cont = 0;
        SwitchChar();
    }

    void Update() {
        KeyListener();
    }
    
    void KeyListener(){
        if(Input.GetButtonDown("Fire1")){
            _cont++;
            if(_cont >= CharsList.Length){
                _cont = 0;
            }
            CameraFollow.Instance.UpdateCurrent(_cont);
            SwitchChar();
        }
    }

    public void SwitchChar(){
        
        for(int i=0;i<CharsList.Length;i++){
            CharsList[i].GetComponent<Player>().enabled = false;
            CharsList[i].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            CharsList[i].GetComponent<Animator>().enabled = false;
        }
        CharsList[_cont].GetComponent<Player>().enabled = true;
        CharsList[_cont].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        CharsList[_cont].GetComponent<Animator>().enabled = true;

    }

    public void DisableSwitch(){
        SwitchController.enabled = false;
    }
}
