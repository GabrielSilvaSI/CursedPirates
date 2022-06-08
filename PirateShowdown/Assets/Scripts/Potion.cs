using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potion : MonoBehaviour
{
    public GameObject PotionEffect;
    public string lvlname;
    private CircleCollider2D circ;
    private SpriteRenderer spr;

    void Start(){
        circ = GetComponent<CircleCollider2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            circ.enabled = false;
            spr.enabled = false;
            PotionEffect.SetActive(true);
            PotionEffect.GetComponent<Animator>().SetTrigger("effect");
            Invoke("DisableEffect", 0.6f);
        }
    }

    void DisableEffect(){
        PotionEffect.SetActive(false);
        Invoke("LoadEndgame", 1f);
    }

    void LoadEndgame(){
        SceneManager.LoadScene(lvlname);
    }
}
