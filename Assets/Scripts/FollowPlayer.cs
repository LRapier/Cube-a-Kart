using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 2f, -8f);
    private Transform target;

    void LateUpdate()
    {
        this.transform.LookAt(target);
    }
}
