using UnityEngine;

public class PlaneFollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        transform.position = target.position;
        transform.forward = Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized;
    }
}
