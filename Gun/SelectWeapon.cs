using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour
{
    private int _selectedGun = 0;
    [SerializeField] private AudioSource _equip;
    void Start()
    {
        SelectGun();
    }

    void Update()
    {
        // CONTROL: aici vedem daca chiar am schimbat arma
        int previousGun = _selectedGun;

        // aici se face schimbarea
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.E)) // middle mouse UP
        {
            if (_selectedGun >= transform.childCount - 1)
            {
                _selectedGun = 0;
            }
            else
            {
                _selectedGun++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.Q)) // middle mouse DOWN
        {
            if (_selectedGun <= 0)
            {
                _selectedGun = transform.childCount - 1;
            }
            else
            {
                _selectedGun--;
            }
        }

        // daca am schimbat arma
        if (previousGun != _selectedGun)
        {
            SelectGun();
        }
    }

    private void SelectGun()
    {
        int i = 0;
        foreach (Transform gun in transform)
        {
            if (i == _selectedGun)
            {
                _equip.Play();
                gun.gameObject.SetActive(true);
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
