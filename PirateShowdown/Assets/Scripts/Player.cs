using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public Transform GroundDetect;
    public LayerMask IsGround;
    public GameObject[] FriendList;


    public static Player Instance;

    private bool OnGround; 
    private bool OnFriend; 
    private Animator Anim;
    private Rigidbody2D Rig;
    private BoxCollider2D BoxCol;
    private Player PlayerScript;


    void Start()
    {
        Instance = this;
        Anim = GetComponent<Animator>();
        Rig = GetComponent<Rigidbody2D>();
        BoxCol = GetComponent<BoxCollider2D>();
        PlayerScript = GetComponent<Player>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * (Time.deltaTime * Speed);

        if(Input.GetAxis("Horizontal") > 0f){
            transform.eulerAngles = new Vector3(0f,0f,0f);
            Anim.SetBool("run", true);
        }
        if(Input.GetAxis("Horizontal") < 0f){
            transform.eulerAngles = new Vector3(0f,180f,0f);
            Anim.SetBool("run", true);
        }
        if(Input.GetAxis("Horizontal") == 0){
            Anim.SetBool("run", false);
        }
    }

    void Jump(){
        OnGround = Physics2D.OverlapCircle(GroundDetect.position, 0.1f, IsGround);
        OnFriend = false;
        for(int i=0;i<FriendList.Length;i++){
            if(Physics2D.OverlapCircle(GroundDetect.position, 0.1f, LayerMask.GetMask(FriendList[i].name))){
                OnFriend = true;
            }
        }
        
        if(Input.GetButtonDown("Jump") && ((OnGround == true) || (OnFriend == true))){
            Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            Anim.SetBool("jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Anim.SetBool("jump", false);
        if (collision.gameObject.tag == "DeadObject")
        {
            PlayerDead();
        }
    }

    void PlayerDead(){
        Anim.SetTrigger("dead");
        PlayerScript.enabled = false;
        GameController.Instance.DisableSwitch();
        UiController.Instace.Invoke("MenuDead", 1);
    }

}
