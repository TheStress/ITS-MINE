using UnityEngine;

public class PointToCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 pointToCamera = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(-pointToCamera.normalized, Camera.main.transform.up);
    }
}
