using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class generator : MonoBehaviour
{
    private List<GameObject> steps , Holes , step_checks;
    public int PreGenerated_Steps;
    public int size;
    public Transform stairs;
    public Transform bank;
    private bool[][] change = new bool[][]{
        new bool[] {true,true,false},
        new bool[] {true,true,true},
        new bool[] {false,true,true}
    };
    private bool[][] options;
    private List<bool[]> valid_options = new List<bool[]>();
    private bool[] last_step = new bool[] {true,true,true};
    private int rnd_num;
    private static int step_cycle=0 , step_check_cycle=0 , hole_cycle=0;
    private void Start(){
        start_game_code.OnIntroStart += PreGenerate;
        load_bank.OnBankLoaded += list_objects;
        options = new bool[Mathf.RoundToInt(Mathf.Pow(2,size))-1][];
        int o = 0;
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int z = 0; z < 2; z++)
                {
                    if (x==0&&y==0&&z==0)
                    {
                        continue;
                    }
                    options[o++]=new bool[] {x==0,y==0,z==0};
                }
            }
        }

    }

    private void list_objects(){
        steps = new List<GameObject>(GameObject.FindGameObjectsWithTag("stair_step"));
        Holes = new List<GameObject>(GameObject.FindGameObjectsWithTag("pit"));
        step_checks = new List<GameObject>(GameObject.FindGameObjectsWithTag("step_check"));
    }
    private void PreGenerate(){
        for (float l = 0; l < PreGenerated_Steps/2; l+=0.5f)
        {
             for (int i = -size+2; i < size-1; i++)
            {
                steps[step_cycle].transform.SetParent(stairs);
                steps[step_cycle].transform.position = new Vector3(i,l,l);
                
                if (step_cycle>=steps.Count-1)
                {
                    step_cycle=0;
                }
                else{
                    step_cycle++;
                }
            }
            step_checks[step_check_cycle].transform.SetParent(stairs);
            step_checks[step_check_cycle].transform.position = new Vector3(0,l,l);
            if (step_check_cycle>=step_checks.Count-1)
            {
                step_check_cycle=0;
            }
            else{
                step_check_cycle++;
            }
        }
    }
    void Generate(){
        valid_options.Clear();
        foreach (bool[] option in options)
        {
            for (int tile = 0; tile < option.Length; tile++)
            {
                if (option[tile]==true&&option[tile] & last_step[tile])
                {
                    valid_options.Add(option);
                }
            }
        }
        last_step = new bool[size];
        bool[] step = valid_options[Random.Range(0,valid_options.Count)];
        int p = -size+2;
        step_checks[step_check_cycle].transform.SetParent(stairs);
        step_checks[step_check_cycle].transform.position = new Vector3(0,PreGenerated_Steps/2-1,PreGenerated_Steps/2-1);
        if (step_check_cycle>=step_checks.Count-1)
        {
            step_check_cycle=0;
        }
        else{
            step_check_cycle++;
        }
        for (int tile = 0; tile < step.Length; tile++)
        {
            if (step[tile])
            {
                steps[step_cycle].transform.SetParent(stairs);
                steps[step_cycle].transform.position = new Vector3(p,PreGenerated_Steps/2-1,PreGenerated_Steps/2-1);
                
                if (step_cycle>=steps.Count-1)
                {
                    step_cycle=0;
                }
                else{
                    step_cycle++;
                }
                if (tile==0&&tile!=size-1)
                {
                    last_step[tile]=true;
                    last_step[tile+1]=true;
                }
                else
                {
                    if(tile==size-1&&tile!=0)
                    {
                        last_step[tile-1]=true;
                        last_step[tile]=true;
                    }
                    else
                    {
                        if (tile==0&&tile==size-1)
                        {
                            last_step[tile]=true;
                        }
                        else
                        {
                            last_step[tile]=true;
                            last_step[tile-1]=true;
                            last_step[tile+1]=true;
                        }
                    }
                }
            }
            else{
                Holes[hole_cycle].transform.SetParent(stairs);
                Holes[hole_cycle].transform.position = new Vector3(p,PreGenerated_Steps/2-1,PreGenerated_Steps/2-1);
                
                if (hole_cycle>=Holes.Count-1)
                {
                    hole_cycle=0;
                }
                else{
                    hole_cycle++;
                }
            }
            p++;
            
        }
    }
    // private void Generate_options(int depth){
    //     int o=0;
    //     for (int x = 0; x < size; x++)
    //     {
    //         for (int i = x; i < 2; i++)
    //         {
                
    //         }
    //     }
    // }
}
