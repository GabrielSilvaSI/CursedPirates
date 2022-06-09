using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Speed;
    public float MoveTime;

    private bool _dirUp;
    private float _timer;

    void Update()
    {
        if(_dirUp){
            transform.Translate(Vector2.down * (Speed * Time.deltaTime));
        }else{
            transform.Translate(Vector2.up * (Speed * Time.deltaTime));
        }
        _timer += Time.deltaTime;
    
        if(_timer >= MoveTime){
            _dirUp = !_dirUp;
            _timer = 0f;
        }
    }
}
