using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviorMouse : MonoBehaviour
{
    public Vector3 CamOffset = new Vector3 (0f, 1.2f, -2.6f);

    public float panSpeed = 5f;

    private Transform _target;

    private Vector3 mouseOrigin;
    private bool isPanning;
    private float yaw;
    private float pitch;
    private float yaw_offset = -5f;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find ("Player").transform;

        this.transform.position = _target.TransformPoint (CamOffset);
        this.transform.LookAt (_target);

        yaw = -this.transform.rotation.y + yaw_offset;
        pitch = this.transform.rotation.x;
        this.transform.localRotation = Quaternion.Euler (yaw, pitch, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        if (!Input.GetMouseButton (0))
        {
            isPanning = false;
        }
    }

    void LateUpdate()
    {
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition
                                             - mouseOrigin);

            yaw += -pos.y * panSpeed * Time.deltaTime;
            pitch += pos.x * panSpeed * Time.deltaTime;

            this.transform.localRotation = Quaternion.Euler (yaw, pitch, 0);
        }
    }
}
