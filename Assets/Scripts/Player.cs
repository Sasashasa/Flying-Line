using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject deadEffectObj;
    public GameObject itemEffectObj;

    Rigidbody2D rb;
    [SerializeField] private float angle = 0;

    public int xSpeed = 3;
    public int ySpeed = 5;

    GameManager gameManager;

    bool isDead = false;

    float hueValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
                rb.AddForce(new Vector2 (0, ySpeed));
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(new Vector2 (0, -ySpeed/1.5f));
            }
            else
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
        
    }


    void GetItem(Collider2D other)
    {
        SetBackgroundColor();
        
        Destroy (Instantiate(itemEffectObj, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject.transform.parent.gameObject);

        gameManager.AddScore();
    }


    void Dead()
    {
        isDead = true;
        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        Destroy (Instantiate(deadEffectObj, transform.position, Quaternion.identity), 0.7f);

        StopPLayer();

        gameManager.CallGameOver();
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

}
