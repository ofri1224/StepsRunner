using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_target_FPS : MonoBehaviour
{
    private void Awake() {
        if(Application.isMobilePlatform){
            Application.targetFrameRate=16;
        }
        else{
            Application.targetFrameRate=30;
        }
    }
}
