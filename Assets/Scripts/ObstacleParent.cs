using System.Collections;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    private Transform _hero;

    private void Start()
    {
        _hero = GameObject.Find("Hero").transform;
        StartCoroutine(CalculateDistanceToPlayer());
    }

    private IEnumerator CalculateDistanceToPlayer()
    {
        if (_hero.transform.position.y - transform.position.y > 50)
        {
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(CalculateDistanceToPlayer());
    }
}
