using UnityEngine;

public class FollowHero : MonoBehaviour
{
    [Header("Герой")]
    [SerializeField] private Transform hero;

    [Header("Характеристики")]
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private int yOffset = 5;
    [SerializeField] private int posZ = -10;

    [Header("Вспомогательные поля")]
    private Vector3 _velocity;
    
    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 tempPos = new Vector3(0, yOffset, posZ);
        Vector3 targetPosition = hero.TransformPoint(tempPos);
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
}
