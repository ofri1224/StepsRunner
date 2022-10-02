using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision_check : MonoBehaviour
{
    public delegate void game_over();
    public delegate void score_up(int num);
    public static event game_over OnGameOver;
    public static event score_up OnScoreUp;
    public GameObject score_text;
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "stair_step"){
            if (OnScoreUp!=null)
            {
                            OnScoreUp(1);
            }
        }
        if(collision.gameObject.tag=="pit"){
            OnGameOver();
        }
    }
}
