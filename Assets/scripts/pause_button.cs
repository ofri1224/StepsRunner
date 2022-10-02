using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pause_button : MonoBehaviour
{
    public GameObject pause_screen;

    void Start(){
        this.GetComponent<Button>().onClick.AddListener(pause_game);
    }
    void pause_game(){
        Debug.Log("button clicked");
        if(Time.timeScale==0){
            Time.timeScale=1;
            pause_screen.SetActive(false);
        }
        else{
            Time.timeScale=0;
            pause_screen.SetActive(true);
        }
    }
}
