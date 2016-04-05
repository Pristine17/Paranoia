using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPosition = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing*Time.deltaTime);

    }

}
