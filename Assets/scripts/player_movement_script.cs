using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class player_movement_script : MonoBehaviour
{
    public float sensitivity = 25;
    [SerializeField]
    private bool detectSwipeOnlyOnRelease = true;
    private Vector2 down_position;
    private bool down = false;

    private bool started = false;
    private Vector2 up_position;

    private void Start() {
        start_game_code.OnStartedGame += game_start;
    }
    void Update()
    {
        if(started){
            if(Input.GetMouseButtonDown(0)){
            down_position = Input.mousePosition;
            down = true;
            }
            if(Input.GetMouseButtonUp(0)&&down){
                up_position = Input.mousePosition;
                detectSwipe();
                down = false;
            }
            if(Input.touchCount>0){
                if(Input.GetTouch(0).phase == TouchPhase.Began){
                    down_position = Input.GetTouch(0).position;
                    down=true;
                }
                if(!detectSwipeOnlyOnRelease&&Input.GetTouch(0).phase == TouchPhase.Moved&&down){
                    up_position = Input.GetTouch(0).position;
                    detectSwipe();
                }
                if(Input.GetTouch(0).phase == TouchPhase.Ended&&down){
                    up_position = Input.GetTouch(0).position;
                    detectSwipe();
                    down=false;
                }
            }
        }
    }
    private void detectSwipe(){
        if(down_position.x-up_position.x>sensitivity&&transform.position.x>=0){
            transform.position=new Vector3(transform.position.x-1,transform.position.y,transform.position.z);
        }
        if(down_position.x-up_position.x<sensitivity&&transform.position.x<=0){
            transform.position=new Vector3(transform.position.x+1,transform.position.y,transform.position.z);
        }
    }
    private void game_start(){
        started=true;
    }
}
