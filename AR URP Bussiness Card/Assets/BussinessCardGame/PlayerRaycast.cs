using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{    
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject birdPrefabe;
    private Camera cam;
    [SerializeField] private float gapbtnbulletshoot = 1.6f;
    private bool canshoot = true;
    public int Shoot = 3;
    public static PlayerRaycast instance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Birdinstance());
        StartCoroutine(Birdinstance());
        if (cam == null)
        {
            cam = Camera.main;
        }
        if (instance== null)
        {
            instance = this;
        }
    }

    public void shoot()
    {
        if (canshoot)
        {
            StartCoroutine(firebullet());
        }
        canshoot = false;
    }
    private IEnumerator firebullet()
    {
        Gun.instance.gunshot();
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo, 100, layer))
        {
            Debug.Log(hitinfo.collider.gameObject.name);
            Destroy(hitinfo.collider.gameObject);
            GameManager.instance.scoreprop += 15;
            StartCoroutine(Birdinstance());
            Shoot = 3;
        }
        else Shoot--;
        GameManager.instance.BulletCount();
        yield return new WaitForSeconds(gapbtnbulletshoot);
        canshoot = true;
    }
    private IEnumerator Birdinstance()
    {
        yield return new WaitForSeconds(2f);
        GameObject bird = Instantiate(birdPrefabe);
        Vector3 temp; 
      
        bird.transform.parent = GameObject.Find("ImageTarget").transform; 
        temp.x = Random.Range(-45f, 45f);
        temp.y = Random.Range(0f, 15f);
        temp.z = Random.Range(0, 70f);
        bird.transform.position = temp;
    }
}
