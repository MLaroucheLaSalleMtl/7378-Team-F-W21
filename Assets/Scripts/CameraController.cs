using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public static CameraController instance;
    public Camera cam;
    // Start is called before the first frame update
    private void Awake()
    {
        instance=this;
    }
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }
}
