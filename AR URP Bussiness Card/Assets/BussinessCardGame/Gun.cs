using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun instance;
    private AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        audios = GetComponent<AudioSource>();
    }

   public void gunshot()
    {
        audios.Play();
    }
}
