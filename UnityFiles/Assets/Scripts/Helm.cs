using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helm : MonoBehaviour
{
    public GameObject MovingObject;
    public float MoveTime;
    public float Speed;

    private Animator anim;
    private CircleCollider2D circ;
    private bool open;
    private float timer;

    void Start() {
        anim = GetComponent<Animator>(); 
        circ = GetComponent<CircleCollider2D>(); 
        open = false;
    }

    void Update() {
        if(open && timer<=MoveTime){
            MovingObject.transform.Translate(Vector2.right * Speed * Time.deltaTime);
            timer += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            anim.SetTrigger("turn");
            circ.enabled = false;
            open = true;
        }
    }

}
