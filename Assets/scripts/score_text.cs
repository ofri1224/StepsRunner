using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_text : MonoBehaviour
{
    private int score = 0;
    public Text Score_Text;

    void Start(){
        start_game_code.OnStartedGame += reset_score;
        player_collision_check.OnScoreUp += ScoreUp;
    }

    private void reset_score(){
        score=0;
        Update_score();
    }


    void Update_score()
    {
        Score_Text.text = score.ToString().PadLeft(6,'0');
    }
    public void ScoreUp(int x){
        score+=x;
        Update_score();
    }
}
