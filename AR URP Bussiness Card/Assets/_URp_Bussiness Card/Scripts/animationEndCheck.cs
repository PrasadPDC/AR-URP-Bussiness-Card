using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEndCheck : MonoBehaviour
{
    public bool animationDone = false;
   
    public void animationIsdone()
    {
        animationDone = true;
    }
    public void animationfalse()
    {
        animationDone = false;
    }
}
