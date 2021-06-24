using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [Header("Характеристики героя")]
    [SerializeField] private int xSpeed = 3;
    [SerializeField] private int ySpeed = 5;

    [Header("Префабы")]
    [SerializeField] private GameObject deadEffectObj;
    [SerializeField] private GameObject itemEffectObj;
    [SerializeField] private GameObject coinEffectObj;

    [Header("Компоненты")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ArcadeGameManager arcadeGameManager;
    [SerializeField] private SoundEffector soundEffector;

    [Header("Вспомогательные поля")]
    private Rigidbody2D _rb;
    private Camera _cam;
    private float _hueValue;
    private float _angle = 0;
    private bool _isDead = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }
   
    private void Start()
    {
        SetBackgroundColor();
    }


    private void FixedUpdate()
    {
        if (!_isDead)
        {
            MoveHeroX();
            MoveHeroY();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Obstacle>()) 
        {
            Dead();
        }
        else if (other.CompareTag("Item"))
        {
            CollectItem(other);
        }
        else if (other.CompareTag("Finish"))
        {
            Win();
        }
        else if (other.CompareTag("Coin"))
        {
            CollectCoin(other);
        }

    }

    private void MoveHeroX()
    {
        _angle += Time.fixedDeltaTime * xSpeed;

        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(_angle) * xSpeed;

        transform.position = pos;
    }


    private void  MoveHeroY()
    {
        if (Time.timeScale > 0) 
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0)) 
            {
                _rb.AddForce(new Vector2(0, ySpeed));
            }
            else 
            {
                if (_rb.velocity.y > 0) 
                {
                    _rb.AddForce(new Vector2(0, -ySpeed / 1.5f));
                }
                else 
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, 0);
                }
            }
        }
    }


    private void CollectCoin(Collider2D other) 
    {
        soundEffector.PlayCollectCoinSound();

        PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount", 0) + 1);

        Destroy(Instantiate(coinEffectObj, other.gameObject.transform.position, Quaternion.identity), 1f);
        Destroy(other.gameObject);
    }


    private void CollectItem(Collider2D other)
    {
        soundEffector.PlayCollectItemSound();

        SetBackgroundColor();
        
        Destroy (Instantiate(itemEffectObj, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject.transform.parent.gameObject);

        if (arcadeGameManager != null) 
        {
            arcadeGameManager.AddScore();
        }
        else 
        {
            gameManager.AddScore();
        }
    }


    private void Dead()
    {
        soundEffector.PlayLoseSound();

        _isDead = true;
        _cam.GetComponent<CameraShake>().ShakeCamera();

        Destroy (Instantiate(deadEffectObj, transform.position, Quaternion.identity), 0.7f);

        StopPLayer();

        if (arcadeGameManager != null) 
        {
            arcadeGameManager.CallGameOver();
        }
        else 
        {
            gameManager.CallGameOver();
        }
    }


    private void SetBackgroundColor()
    {
        _hueValue = Random.Range(0, 10) / 10.0f;
        _cam.backgroundColor = Color.HSVToRGB(_hueValue, 0.6f, 0.8f);
    }

    private void Win()
    {
        soundEffector.PlayWinSound();
        gameManager.ActicateWinPanel();

        StopPLayer();
        CheckPassedLevels();
        SetStars(); 
    }

    private void StopPLayer()
    {
        _rb.velocity = new Vector2(0, 0);
        _rb.isKinematic = true;
    }


    private void CheckPassedLevels() 
    {
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LvlsPassed"))
        {
            PlayerPrefs.SetInt("LvlsPassed", SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void SetStars() 
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
