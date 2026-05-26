using UnityEngine;

public class FollowPlayerUI : MonoBehaviour
{
    public Transform playerCamera;

    void Update()
    {
        Vector3 direction = playerCamera.position - transform.position;

        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);

        transform.Rotate(0, 180, 0);
    }
}