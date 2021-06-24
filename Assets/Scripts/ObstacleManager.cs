using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Префабы и игровые объекты")]
    [SerializeField] private Transform hero;
    [SerializeField] private GameObject[] componentObstacles;

    [Header("Характеристики")]
    [SerializeField] private int distanceToNext = 50;

    [Header("Вспопмгательные поля")]
    private int _obstacleCount;
    private int _playerDistanceIndex = -1;
    private int _obstacleIndex = 0;
    
    private void Start()
    {
        _obstacleCount = componentObstacles.Length;
        InstantientObstacle();
    }

    
    private void Update()
    {
        int PlayerDistance = (int) (hero.position.y / distanceToNext);

        if (_playerDistanceIndex != PlayerDistance)
        {
            InstantientObstacle();
            _playerDistanceIndex = PlayerDistance;
        }
    }

    private void InstantientObstacle()
    {
        int randomId = Random.Range(0, _obstacleCount);
        GameObject obstacle = componentObstacles[randomId];
        Vector3 pos = new Vector3(0, _obstacleIndex * distanceToNext);

        GameObject newObstacle = Instantiate(obstacle, pos, Quaternion.identity);

        newObstacle.transform.SetParent(transform);
        _obstacleIndex++;
    }
}
