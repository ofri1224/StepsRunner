using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_start_roatation : MonoBehaviour
{
    public float rotation_speed;
    [SerializeField]
    private Vector3 degrees;

    private bool intro=false;
    [SerializeField]
    private Vector3 start_pos = new Vector3(4.8f,3.2f,0);
    [SerializeField]
    private Vector3 pivot_point = new Vector3(0f,3.2f,0f);
    [SerializeField]
    private Vector3 goal_pos = new Vector3(0,3.2f,-4.8f);

    private int counter=0;

    private void Start(){
        start_game_code.OnIntroStart += intro_rotate_cam;
    }
    private void FixedUpdate() {
        if(intro){
            counter++;
            transform.position = ((Quaternion.Euler(degrees.normalized*rotation_speed)) *(transform.position - pivot_point))+ pivot_point;
            transform.LookAt(pivot_point,Vector3.up);
            if(transform.position==goal_pos){
                intro=false;
                start_game_code.start_game();
            }
        }
    }
    private void intro_rotate_cam(){
        intro=true;
        // Debug.Log(degrees.normalized);
        // for (int counter = 0; counter < 90; counter+=rotation_speed)
        // {
        //     pos = new Vector3 ( 
        //     start_pos.x + Mathf.Sin( Mathf.PI * 2 * counter / 360), 
        //     start_pos.y,
        //     start_pos.z + Mathf.Sin( Mathf.PI * 2 * counter / 360)
        //     );
        //     Debug.Log(pos);
        //     transform.position = Vector3.Lerp(transform.position,pos, 1f);
        // }
        
    }
    // camera game goal transform (0,3.2,-4.8)
}
