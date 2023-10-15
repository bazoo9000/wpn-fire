using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Animator _muzzleFlash;

    [SerializeField] private float _damage;
    public LayerMask _whatCanHit;
    private bool _canFire = true;
    private float _timer;
    [SerializeField] private float _fireRate;
    private float _originalRate;
    private bool _applyOnce = true;

    [SerializeField] private Ammo _ammo;

    [SerializeField] private float _recoilAngle = 5f;
    [SerializeField] private Movement _move;

    [SerializeField] private Transform _shellEjector;
    [SerializeField] private Rigidbody2D _shell;
    private float _randomExtractionForce;
    private float _randomTorque;

    [SerializeField] private bool isShotgun = false;

    [SerializeField] private bool isFiringProjectiles = false; // grenade launcher, stinger, flak cannon
    [SerializeField] GameObject _projectile;

    [SerializeField] GameObject _bloodEffect;
    [SerializeField] GameObject _targetEffect;
    [SerializeField] GameObject _impactEffect;

    private void Start()
    {
        _originalRate = _fireRate;
    }

    void Update()
    {
        if (Berserk._isBerserk && _applyOnce)
        {
            _fireRate -= _fireRate / 3;
            _applyOnce = false;
            Berserk.Stop();
        }
        else
        {
            _fireRate = _originalRate;
            _applyOnce = true;
        }

        if (!_canFire)
        {
            Stop();
        }

        if (Input.GetButton("Fire1") && _canFire && !PauseMenuScripts._isPaused)
        {
            if (_ammo._ammo != 0)
            {
                if (!isFiringProjectiles)
                {
                    StartCoroutine(Fire());
                }
                else
                {
                    if (!isShotgun)
                    {
                        FireProjectile(_projectile);
                    }
                    else
                    {
                        FireMultipleProjectiles(_projectile, Random.Range(5, 10));
                    }
                }
            }
            else
            {
                _ammo.Click();
            }
        }
    }

    IEnumerator Fire()
    {
        _ammo._ammo--;
        _canFire = false;

        if (!isShotgun && !isFiringProjectiles)
        {
            //Recoil
            float aux = _gunPoint.transform.eulerAngles.z;
            float angle;
            if (_move.horizontal != 0)
            {
                angle = Random.Range(-2 * _recoilAngle, 2 * _recoilAngle);
            }
            else
            {
                angle = Random.Range(-_recoilAngle, _recoilAngle);
            }
            _gunPoint.transform.Rotate(0, 0, angle);

            //Shoot Bullet (mai exact ii un laser :P)
            RaycastHit2D hitInfo = Physics2D.Raycast(_gunPoint.position, _gunPoint.right, 12.5f, _whatCanHit);
            _audioSource.Play();
            if (hitInfo) // daca nimereste ceva
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                Target target = hitInfo.transform.GetComponent<Target>();
                if (enemy != null)
                {
                    enemy.TakeDamage(_damage);
                    Instantiate(_bloodEffect, hitInfo.point, Quaternion.identity);
                }
                else if (target != null)
                {
                    target.TakeDamage();
                    Transform rot = hitInfo.transform;
                    rot.Rotate(0f, 0f, 180f);
                    Instantiate(_targetEffect, hitInfo.point, rot.rotation);
                }
                else //if (hitInfo.transform.tag == "Ground")
                {
                    Instantiate(_impactEffect, hitInfo.point + new Vector2(0f, 0.2f), Quaternion.identity);
                }
                _lineRenderer.SetPosition(0, _gunPoint.position);
                _lineRenderer.SetPosition(1, hitInfo.point);
            }
            else // daca NU nimereste ceva
            {
                _lineRenderer.SetPosition(0, _gunPoint.position);
                _lineRenderer.SetPosition(1, _gunPoint.position + _gunPoint.right * 12.5f);
            }

            ExtractShell();
            _lineRenderer.enabled = true;
            _muzzleFlash.SetBool("isFiring", true);
            _muzzleFlash.SetInteger("id", Random.Range(0, 6));
            yield return new WaitForSeconds(0.02f); // exact 1 frame
            _lineRenderer.enabled = false;
            _muzzleFlash.SetBool("isFiring", false);
            _muzzleFlash.SetInteger("id", Random.Range(0, 6));

            //Reset position for Recoil
            _gunPoint.transform.Rotate(0, 0, -angle);
        }
        else if (isShotgun)
        {
            float aux = _gunPoint.transform.eulerAngles.z;
            float[] angle = { 0, 0, 0, 0, 0 };
            LineRenderer[] shots = GetComponentsInChildren<LineRenderer>();
            for (int i = 0; i < 5; i++)
            {
                angle[i] = Random.Range(-2 * _recoilAngle, 2 * _recoilAngle);
                for (int j = 0; j < 0; j++)
                {
                    if (Mathf.Abs(angle[i] - angle[j]) <= 0.2f)
                    {
                        angle[i] = Random.Range(-2 * _recoilAngle, 2 * _recoilAngle);
                        break;
                    }
                }
                _gunPoint.transform.Rotate(0, 0, angle[i]);
                RaycastHit2D hitInfo = Physics2D.Raycast(_gunPoint.position, _gunPoint.right, 12.5f, _whatCanHit);
                if (hitInfo) // daca nimereste ceva
                {
                    Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                    Target target = hitInfo.transform.GetComponent<Target>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(_damage);
                        Instantiate(_bloodEffect, hitInfo.point, Quaternion.identity);
                    }
                    else if (target != null)
                    {
                        target.TakeDamage();
                        Transform rot = hitInfo.transform;
                        rot.Rotate(0f, 0f, 180f);
                        Instantiate(_targetEffect, hitInfo.point, rot.rotation);
                    }
                    else //if (hitInfo.transform.tag == "Ground")
                    {
                        Instantiate(_impactEffect, hitInfo.point + new Vector2(0f, 0.2f), Quaternion.identity);
                    }
                    shots[i].SetPosition(0, _gunPoint.position);
                    shots[i].SetPosition(1, hitInfo.point);
                }
                else // daca NU nimereste ceva
                {
                    shots[i].SetPosition(0, _gunPoint.position);
                    shots[i].SetPosition(1, _gunPoint.position + _gunPoint.right * 12.5f);
                }
                shots[i].enabled = true;
                _gunPoint.transform.Rotate(0, 0, -angle[i]);
            }
            _audioSource.Play();

            ExtractShell();
            _muzzleFlash.SetBool("isFiring", true);
            _muzzleFlash.SetInteger("id", Random.Range(0, 6));
            yield return new WaitForSeconds(0.02f); // exact 1 frame
            foreach (LineRenderer line in shots)
            {
                line.enabled = false;
            }
            _muzzleFlash.SetBool("isFiring", false);
            _muzzleFlash.SetInteger("id", Random.Range(0, 6));
        }
    }
    private void FireProjectile(GameObject projectile)
    {
        _ammo._ammo--;
        _canFire = false;
        _audioSource.Play();
        Instantiate(projectile, _gunPoint.position, _gunPoint.rotation);
    }
    private void FireMultipleProjectiles(GameObject projectile, int nrProj)
    {
        _ammo._ammo--;
        _canFire = false;
        _audioSource.Play();
        float angle;
        for (int i = 0; i < nrProj; i++)
        {
            angle = Random.Range(-4 * _recoilAngle, 4 * _recoilAngle);
            _gunPoint.Rotate(0f, 0f, angle);
            Instantiate(projectile, _gunPoint.position, _gunPoint.rotation);
            _gunPoint.Rotate(0f, 0f, -angle);
        }
    }
    private void Stop()
    {
        _timer += Time.deltaTime;
        if (_timer > _fireRate)
        {
            _canFire = true;
            _timer = 0;
        }
    }
    private void ExtractShell()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        _randomExtractionForce = Random.Range(300f, 400f); // DA EJECTIN FORS

        _randomTorque = Random.Range(500f, 1000f); // DA SPIN

        float angle = Random.Range(-15f, 15f);
        _shellEjector.Rotate(0f, 0f, angle); // DA ANGAL

        var extractedShell = Instantiate(_shell, _shellEjector.position, _shellEjector.rotation);
        extractedShell.AddForce(_shellEjector.up * _randomExtractionForce, ForceMode2D.Force);
        extractedShell.AddTorque(_randomTorque);

        _shellEjector.Rotate(0f, 0f, -angle); // DA ANGAL BUT REVERSE (for reseting)
    }
}
