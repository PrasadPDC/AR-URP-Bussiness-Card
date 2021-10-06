using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI finalscoretext;
    [SerializeField] private TextMeshProUGUI livetext;
    [SerializeField] private int score = 0;
    [SerializeField] private Image[] bulletImage;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip GameOverAudio;
    [SerializeField] private AudioClip LifeDecreseAudio;
    public int scoreprop { 
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    [SerializeField] private int live = 3;
    public int liveprop
    {
        get
        {
            return live;
        }
        set
        {
          live = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("BirdGameAudio");
        if (instance == null)
        {
            instance = this;
        }
        GameOverPanel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        finalscoretext.text = score.ToString();
        scoretext.text = score.ToString(); 
        livetext.text = live.ToString();
        if (PlayerRaycast.instance.Shoot == 3)
        {
            bulletImage[0].enabled = true;
            bulletImage[1].enabled = true;
            bulletImage[2].enabled = true;
        }
       
    }
    public void BulletCount()
    {
        
        if (PlayerRaycast.instance.Shoot == 2)
        {
            bulletImage[0].enabled = false;
            bulletImage[1].enabled = true;
            bulletImage[2].enabled = true;
        }
        else if (PlayerRaycast.instance.Shoot == 1)
        {
            bulletImage[0].enabled = false;
            bulletImage[1].enabled = false;
            bulletImage[2].enabled = true;
        }
        else if (PlayerRaycast.instance.Shoot == 0)
        {
            bulletImage[0].enabled = false;
            bulletImage[1].enabled = false;
            bulletImage[2].enabled = false;
            live--;
            AudioSource.PlayOneShot(LifeDecreseAudio);
            if (live > 0)
            {
                PlayerRaycast.instance.Shoot = 3;
            }
            if(live == 0 )
            {
                GameOverPanel.SetActive(true);
                AudioSource.PlayOneShot(GameOverAudio);
            }
        }

    }
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AudioManager.instance.Play("MenuAudio");
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void backButton()
    {
        AudioManager.instance.Play("MenuAudio");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
    }
}
