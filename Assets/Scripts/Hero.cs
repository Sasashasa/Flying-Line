using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{

    public GameObject deadEffectObj;
    public GameObject itemEffectObj;
    public GameObject coinEffectObj;

    Rigidbody2D rb;
    [SerializeField] private float angle = 0;

    public int xSpeed = 3;
    public int ySpeed = 5;

    [SerializeField] ArcadeGameManager arcadeGameManager;
    [SerializeField] GameManager gameManager;

    bool isDead = false;

    float hueValue;

    public GameUIManager uiManager;

    public SoundEffector sE;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().name == "ArcadeMode")   arcadeGameManager = GameObject.Find("ArcadeGameManager").GetComponent<ArcadeGameManager>();
        if (SceneManager.GetActiveScene().name != "ArcadeMode") gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
   
    private void Start()
    {
        hueValue = Random.Range(0,10) / 10.0f;
        SetBackgroundColor();
    }


    private void Update()
    {
        if (isDead == true) 
        {
            return;
        }

        MovePlayer();
        GetInput();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            sE.PlayLoseSound();
            Dead();
        }
        else if (other.gameObject.tag == "Item")
        {
            sE.PlayCollectItemSound();
            GetItem(other);
        }
        else if (other.gameObject.tag == "Finish")
        {
            sE.PlayWinSound();
            Win();
        }
        else if (other.gameObject.tag == "Coin")
        {
            PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount", 0) + 1);
            sE.PlayCollectCoinSound();
            Destroy(Instantiate(coinEffectObj, other.gameObject.transform.position, Quaternion.identity), 1f);
            Destroy(other.gameObject);
        }

    }


    private void MovePlayer()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle)*3;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }


    private void  GetInput()
    {
        
        if ((Input.touchCount > 0 || Input.GetMouseButton(0)) && Time.timeScale > 0)
        {
                rb.AddForce(new Vector2 (0, ySpeed));
        }
        else
        {
            if (rb.velocity.y > 0 && Time.timeScale > 0)
            {
                rb.AddForce(new Vector2 (0, -ySpeed/1.5f));
            }
            else if (Time.timeScale > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
           
        }
    }



    private void GetItem(Collider2D other)
    {
        SetBackgroundColor();
        
        Destroy (Instantiate(itemEffectObj, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject.transform.parent.gameObject);

        if (SceneManager.GetActiveScene().name == "ArcadeMode") arcadeGameManager.AddScore();
        if (SceneManager.GetActiveScene().name != "ArcadeMode") gameManager.AddScore();
    }


    private void Dead()
    {
        isDead = true;
        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        Destroy (Instantiate(deadEffectObj, transform.position, Quaternion.identity), 0.7f);

        StopPLayer();

        if (SceneManager.GetActiveScene().name == "ArcadeMode") arcadeGameManager.CallGameOver();
        if (SceneManager.GetActiveScene().name != "ArcadeMode") gameManager.CallGameOver();
    }

    private void StopPLayer()
    {
        rb.velocity = new Vector2 (0,0);
        rb.isKinematic = true;

    }

    private void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);

        hueValue += 0.1f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }

    private void Win()
    {
        StopPLayer();
        gameManager.WinPanel.SetActive(true);
        CheckPassedLevels();
        SetCrowns(); 
    }

    private void CheckPassedLevels() 
    {
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LvlsPassed"))
        {
            PlayerPrefs.SetInt("LvlsPassed", SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void SetCrowns() 
    {
        int curLevel = SceneManager.GetActiveScene().buildIndex;
        int starsAmount = 0;

        if (PlayerPrefs.HasKey($"Lvl{curLevel}BestScore")) 
        {
            int pointsAmount = PlayerPrefs.GetInt($"Lvl{curLevel}BestScore");

            if (curLevel <= 10) 
            {
                starsAmount = pointsAmount;
            }
            else if (curLevel > 10 && curLevel <= 15) 
            {
                starsAmount = pointsAmount / 2;
            }
            else if (curLevel > 15 && curLevel <= 20)
            {
                starsAmount = pointsAmount / 3;
            }  
        }

        PlayerPrefs.SetInt($"Lvl{curLevel}Stars", starsAmount);
    }
}
