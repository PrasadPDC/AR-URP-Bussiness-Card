using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetFollow : MonoBehaviour
{
    public static targetFollow instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
            
    }
    private void OnTriggerEnter(Collider other)
    {
        onMove();
    }
    public void onMove()
    {
        Vector3 temp;
        temp.x = Random.Range(-45f, 45f);
        temp.y = Random.Range(0f, 14f);
        temp.z = Random.Range(0, 70f);
        transform.position = temp;
    }
}
