using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonInputs : MonoBehaviour
{
    public VideoPlayer video;
    public AudioSource Introaudios;
    public AudioSource Buttonaudios;
    public Animator anim;
    public Animator Playeranim;
    public GameObject info;
    public ParticleSystem partical;

    private animationEndCheck animdone;
    private void Start()
    {
        animdone = FindObjectOfType<animationEndCheck>();
    }
    public void Intro()
    {
        Buttonaudios.Play();
        Introaudios.Play();
        video.Stop();      
    }
    public void skill()
    {
        Buttonaudios.Play();

        if (!info.activeInHierarchy)
        {
            info.SetActive(true);
        }
        else
        {
            info.SetActive(false);
        }   
      
    }
    
    public void Video()
    {
        Buttonaudios.Play();

        if (!video.isPlaying)
        {
            video.Play();
            Playeranim.Play("FadeIn");
            Introaudios.Stop();
            info.SetActive(false);
        }
        else
        {
            Playeranim.Play("FadeOut");
            video.Stop();
        }

    }
    public void contact()
    {
        Buttonaudios.Play();

        if (animdone.animationDone)
        {
            partical.Stop();
            anim.Play("buttonreverse");
        }
        else
        {
            partical.Play();
            anim.Play("button");
        }      
    }

    public void Game()
    {
        Buttonaudios.Play();

        Introaudios.Stop();
        video.gameObject.SetActive(false);
        info.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void SendEmail()

    {

        string email = "prasadchandole999@gmail.com";

        string subject = MyEscapeURL("");

        string body = MyEscapeURL("");


        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);

    }

    string MyEscapeURL(string url)

    {

        return WWW.EscapeURL(url).Replace("+", "%20");

    }
    public void Instagrambutton()
    {
        Application.OpenURL("https://www.instagram.com/prasad_d_chandole/");
    }
    public void Linkedinbutton()
    {
        Application.OpenURL("https://www.linkedin.com/in/prasad-chandole-7539711a1/");
    }
    public void youtubebutton()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC3PP5THw8Wgj4TLc8y0kU7g");
    }
}
