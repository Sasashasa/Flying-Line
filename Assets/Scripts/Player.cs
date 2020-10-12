using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject deadEffectObj;
    public GameObject itemEffectObj;

    Rigidbody2D rb;
    [SerializeField] private float angle = 0;

    public int xSpeed = 3;
    public int ySpeed = 5;

    [SerializeField] ArcadeGameManager arcadeGameManager;
    [SerializeField] GameManager gameManager;

    bool isDead = false;

    float hueValue;

    public UI uiManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().name == "ArcadeMode")   arcadeGameManager = GameObject.Find("ArcadeGameManager").GetComponent<ArcadeGameManager>();
        if (SceneManager.GetActiveScene().name != "ArcadeMode") gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
   
    void Start()
    {
        hueValue = Random.Range(0,10) / 10.0f;
        SetBackgroundColor();
    }


        void Update()
    {
        if (isDead == true) return;

        MovePlayer();

        GetInput();
    }


    void MovePlayer()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle)*3;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }


    void  GetInput()
    {
        
        if ((Input.touchCount > 0 || Input.GetMouseButton(0)) && uiManager.isPause == false)
        {
                rb.AddForce(new Vector2 (0, ySpeed));
        }
        else
        {
            if (rb.velocity.y > 0 && uiManager.isPause == false)
            {
                rb.AddForce(new Vector2 (0, -ySpeed/1.5f));
            }
            else if (uiManager.isPause == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
           
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Obstacle")
        {
            Dead();
        }
        else if (other.gameObject.tag == "Item")
        {
            GetItem(other);
        }
        else if (other.gameObject.tag == "Finish") 
        {
            Win();
        }
        
    }


    void GetItem(Collider2D other)
    {
        SetBackgroundColor();
        
        Destroy (Instantiate(itemEffectObj, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject.transform.parent.gameObject);

        if (SceneManager.GetActiveScene().name == "ArcadeMode") arcadeGameManager.AddScore();
        if (SceneManager.GetActiveScene().name != "ArcadeMode") gameManager.AddScore();
    }


    void Dead()
    {
        isDead = true;
        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        Destroy (Instantiate(deadEffectObj, transform.position, Quaternion.identity), 0.7f);

        StopPLayer();

        if (SceneManager.GetActiveScene().name == "ArcadeMode") arcadeGameManager.CallGameOver();
        if (SceneManager.GetActiveScene().name != "ArcadeMode") gameManager.CallGameOver();
    }


    void StopPLayer()
    {
        rb.velocity = new Vector2 (0,0);
        rb.isKinematic = true;

    }

    void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);

        hueValue += 0.1f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }

    void Win()
    {
        StopPLayer();

        gameManager.WinPanel.SetActive(true);

        CheckPassedLevels();

        SetCrowns(); 
    }


    void CheckPassedLevels() 
    {
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LvlsPassed"))
        {
            PlayerPrefs.SetInt("LvlsPassed", SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetCrowns() 
    {

        if (SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex <= 5)
        {

            for (int i = 1; i < 6; i++)
            {
                if (SceneManager.GetActiveScene().buildIndex == i)
                {
                    if (PlayerPrefs.HasKey("Lvl" + i + "BestScore"))
                    {
                        int crownAmount = 0;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 1) crownAmount = 1;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 2) crownAmount = 2;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 3) crownAmount = 3;

                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", crownAmount);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", 0);
                    }
                }
            }

        }

        else if (SceneManager.GetActiveScene().buildIndex >= 6 && SceneManager.GetActiveScene().buildIndex <= 10)
        {

            for (int i = 6; i < 11; i++)
            {
                if (SceneManager.GetActiveScene().buildIndex == i)
                {
                    if (PlayerPrefs.HasKey("Lvl" + i + "BestScore"))
                    {
                        int crownAmount = 0;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 1) crownAmount = 1;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 2) crownAmount = 2; 
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 3) crownAmount = 3;

                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", crownAmount);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", 0);
                    }
                }
            }

        }

        else if (SceneManager.GetActiveScene().buildIndex >= 11 && SceneManager.GetActiveScene().buildIndex <= 15)
        {

            for (int i = 11; i < 16; i++)
            {
                if (SceneManager.GetActiveScene().buildIndex == i)
                {
                    if (PlayerPrefs.HasKey("Lvl" + i + "BestScore"))
                    {
                        int crownAmount = 0;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 1) crownAmount = 0;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") >= 2 && PlayerPrefs.GetInt("Lvl" + i + "BestScore") <= 3) crownAmount = 1;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") >= 4 && PlayerPrefs.GetInt("Lvl" + i + "BestScore") <= 5) crownAmount = 2;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 6) crownAmount = 3;

                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", crownAmount);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", 0);
                    }
                }
            }

        }

        else if (SceneManager.GetActiveScene().buildIndex >= 15 && SceneManager.GetActiveScene().buildIndex <= 20)
        {

            for (int i = 16; i < 21; i++)
            {
                if (SceneManager.GetActiveScene().buildIndex == i)
                {
                    if (PlayerPrefs.HasKey("Lvl" + i + "BestScore"))
                    {
                        int crownAmount = 0;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") >= 1 && PlayerPrefs.GetInt("Lvl" + i + "BestScore") <= 2) crownAmount = 0;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") >= 3 && PlayerPrefs.GetInt("Lvl" + i + "BestScore") <= 5) crownAmount = 1;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") >= 6 && PlayerPrefs.GetInt("Lvl" + i + "BestScore") <= 8) crownAmount = 2;
                        if (PlayerPrefs.GetInt("Lvl" + i + "BestScore") == 9) crownAmount = 3;

                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", crownAmount);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Lvl" + i + "Crowns", 0);
                    }
                }
            }

        }

    }


}
