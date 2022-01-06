using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTargets : MonoBehaviour
{
    private void FixedUpdate()
    {
        //fait tourner les cibles grace a leur parent
        transform.Rotate(0f,0f,1f);
    }
}
