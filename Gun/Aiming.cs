using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private bool isRotated = false;
    [SerializeField] private GameObject o;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {

        if (!PauseMenuScripts._isPaused)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (isRotated)
            {
                o.transform.Rotate(180f, 0f, 0f);
                isRotated = false;
            }
            if (transform.rotation.eulerAngles.z > 90f && transform.rotation.eulerAngles.z < 270f && !isRotated)
            {
                o.transform.Rotate(180f, 0f, 0f);
                isRotated = true;
            }
        }
    }
}
