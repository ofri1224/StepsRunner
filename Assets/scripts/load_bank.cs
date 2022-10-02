using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_bank : MonoBehaviour
{
    public delegate void bank_loaded();

    public static event bank_loaded OnBankLoaded;

    public int size;
    public int rows_amount;
    public GameObject step_check;
    public GameObject[] gameObjects;
    
    private GameObject g;
    void Start()
    {
        for (int r = 0; r < rows_amount; r++)
        {
            foreach (GameObject gameobject in gameObjects)
            {
                for (int s = 0;s < size; s++)
                {
                    g = GameObject.Instantiate(gameobject,this.transform.position,Quaternion.identity);
                    g.transform.SetParent(this.transform);
                    g.transform.position.Set(0,0,0);
                }
            }
            g = GameObject.Instantiate(step_check,this.transform.position,Quaternion.identity);
            g.transform.SetParent(this.transform);
            g.transform.position.Set(0,0,0);
        }
        OnBankLoaded();
    }
}
