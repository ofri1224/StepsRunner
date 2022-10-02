using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable_layer_collision : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(8,8,true);
    }
}
