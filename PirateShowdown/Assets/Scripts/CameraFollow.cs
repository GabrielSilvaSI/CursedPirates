using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public float yOffset = 1f;
    public Transform[] players;
    public static CameraFollow Instance;

    private int _current;

    void Start(){
        Instance = this;
        _current = 0;
    }

    public void UpdateCurrent(int newPlayer){
        _current = newPlayer;
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if(players[_current])
        {
            var position = players[_current].position;
            Vector3 playerPos = new Vector3(position.x, position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, playerPos, speed * Time.deltaTime);
        }
    }
}
