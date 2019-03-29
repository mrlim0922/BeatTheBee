using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}