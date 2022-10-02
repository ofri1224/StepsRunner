using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_ui_script : MonoBehaviour
{
    private void OnEnable() {
        start_game_code.OnIntroStart += close_ui;
    }

    private void OnDisable() {
        start_game_code.OnIntroStart -= close_ui;
    }

    void close_ui(){
        this.gameObject.SetActive(false);
    }
}
