using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step_movment : MonoBehaviour
{
    public float speed = 1f;
    private static Transform bank;
    private static bool started = false,outro=false;
    private void Awake() {
        load_bank.OnBankLoaded += save_bank;
        start_game_code.OnStartedGame += game_start;
        player_collision_check.OnGameOver += game_over;
    } 
    void Update()
    {
        if(started){
            transform.Translate(new Vector3(0,-1,-1)*Time.deltaTime*speed);
            if(transform.position.y<=-1&&transform.position.z<=-1){
                save_in_bank();
            }
        }
        if (outro)
        {
            transform.position+=new Vector3(0,1,0);
            if (transform.position.y>=30)
            {
                outro=false;
                save_in_bank();
            }
        }
    }
    private void game_start(){
        started=true;
    }
    private void game_over(){
        started=false;
        outro=true;
    }
    private void save_bank(){
        bank = this.GetComponentInParent<Transform>();
    }
    public void save_in_bank(){
        transform.SetParent(bank);
        transform.position = new Vector3(420,420,420);
    }
}
