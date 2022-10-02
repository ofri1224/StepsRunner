using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class start_game_code : MonoBehaviour
{
    public delegate void game_started();

    public static event game_started OnStartedGame;


    public delegate void intro_started();

    public static event intro_started OnIntroStart;

    void Start(){
        this.GetComponent<Button>().onClick.AddListener(intro);
    }


    private void intro(){
        OnIntroStart();
        //GameObject.Find("Main Camera").BroadcastMessage("intro_rotate_cam");
    }
    public static void start_game(){
        if(OnStartedGame!=null){
            OnStartedGame();
        }
        //SendMessageUpwards("close_ui");
    }
}
