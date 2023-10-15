using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFollow : MonoBehaviour
{
    private Camera _mainCam;

    void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.position = _mainCam.gameObject.transform.position;
    }

}
