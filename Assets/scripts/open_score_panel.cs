using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_score_panel : MonoBehaviour
{
    private void Awake() {
        this.gameObject.SetActive(false);
    }
    private void OnEnable() {
        start_game_code.OnStartedGame -= Open_score_panel;
    }

    private void OnDisable() {
        start_game_code.OnStartedGame += Open_score_panel;
    }

    private void Close_score_panel(){
        this.gameObject.SetActive(false);
    }


    private void Open_score_panel(){
        this.gameObject.SetActive(true);
    }
}
