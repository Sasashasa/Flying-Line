using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject PlayerObj;
    public GameObject[] ObstaclesArr;
    int obstacleCount;
    int playerDistanceIndex = -1;
    int obstacleIndex = 0;
    public int distanceToNext = 50;
    
    void Start()
    {
        obstacleCount = ObstaclesArr.Length;
        InstantientObstacle();
    }

    
    void Update()
    {
        int PlayerDistance = (int) (PlayerObj.transform.position.y / (distanceToNext));

        if (playerDistanceIndex != PlayerDistance)
        {
            InstantientObstacle();
            playerDistanceIndex = PlayerDistance;
        }

    }


    public void InstantientObstacle()
    {
        int RandomInt = Random.Range(0, obstacleCount);
        GameObject newObstacle = Instantiate(ObstaclesArr[RandomInt], new Vector3(0, obstacleIndex*distanceToNext), Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;
    }
    
}
