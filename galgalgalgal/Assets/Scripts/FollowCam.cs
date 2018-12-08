using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    Vector3 cameraPos;
    Transform tr;

    private float camHalfWidth;
    private float camHalfHeight;

    private Camera cam;

    public BoxCollider2D box2d;




    // Use this for initialization
    void Start ()
    {

        cam = GetComponent<Camera>();


        tr = GetComponent<Transform>();
        cameraPos = transform.position - target.position;

    }

    // Update is called once per frame
    void Update () {

    }
    private void LateUpdate()
    {
        FollowCamera();
        CameraMovelimit();

    }
    void FollowCamera()
    {
        
        tr.position = cameraPos + target.position;
        tr.LookAt(target.position);
        
    }
    void CameraMovelimit()
    {
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * Screen.width / Screen.height;

        float clampX = Mathf.Clamp(transform.position.x, -15f + camHalfWidth, 178.5f - camHalfWidth);
        float clampY = Mathf.Clamp(transform.position.y, -5.6f + camHalfHeight, 4.85f- camHalfHeight);

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
