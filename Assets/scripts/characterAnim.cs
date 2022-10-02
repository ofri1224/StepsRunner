using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim=gameObject.GetComponent<Animator>();
        start_game_code.OnStartedGame += game_start_anim;
        player_collision_check.OnGameOver += game_over_anim;
    }

    private void game_start_anim(){
        anim.SetTrigger("game_started");
    }



    private void game_over_anim(){
        anim.SetInteger("score",1);
        anim.SetTrigger("game_over");
        anim.ResetTrigger("game_started");

    }
}
