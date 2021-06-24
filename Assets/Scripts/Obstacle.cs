using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int RotationSpeed;

    private void Update()
    {
        if (RotationSpeed != 0)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
    }
}
