using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class test_adaptive_sliders : MonoBehaviour
{
    [Range(0.0f,100.0f)]
    public float[] testsliders;
    private float[] m_testsliders;
    private int changed;
    public float max;
    
    private void Awake(){
        testsliders.CopyTo(m_testsliders,0);
    }

    private void OnValidate() {
        for (int i = 0; i < testsliders.Length; i++)
        {
            if(i>m_testsliders.Length-1||testsliders[i] != m_testsliders[i]){
                
                changed = i;
                break;
            }
        }
        float sum = 0;
        foreach (float slider in testsliders)
        {
            sum+=slider;
        }
        AdjustValueSet(changed,sum);
        m_testsliders = testsliders.Clone() as float[];
    }
    void AdjustValueSet(int changed,float sum) {
        float n_val;
        for (int i = 0; i < testsliders.Length; i++)
        {
            if(i==changed){
                continue;
            }
            n_val = testsliders[i]+((max-sum)/(testsliders.Length-1));
            if(n_val<0||testsliders[changed]==max){
                n_val=0;
            }
            if(n_val>max){
                n_val=max;
            }
            testsliders[i]=n_val;
        }
    }

}
