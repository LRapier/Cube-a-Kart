using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 2f, -8f);
    private Transform target;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
