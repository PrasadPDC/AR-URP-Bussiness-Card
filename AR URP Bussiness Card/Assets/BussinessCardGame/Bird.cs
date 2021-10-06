using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Transform followtarget;
    public AudioSource audios;
    public float soundIntervalTime = 5;


    void Start()
    {
        StartCoroutine(duckSound());

        followtarget = GameObject.FindGameObjectWithTag("target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = followtarget.position - this.transform.position;

        transform.LookAt(followtarget.transform);
     
        if (dir.magnitude < 1f)
        {
            targetFollow.instance.onMove();           
        }

        float speed = Random.Range(1f, 5f);      

        transform.Translate(0, 0, speed * Time.deltaTime);

    }


   
    IEnumerator duckSound()
    {
        audios.Play();
        Debug.Log("isworiking");
        yield return new WaitForSeconds(soundIntervalTime);
        StartCoroutine(duckSound());
    }
}
