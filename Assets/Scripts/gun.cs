using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damge = 10f;
    public float range = 10f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 7;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fbsCam;
    public GameObject impactEffect;
    public ParticleSystem ok;

    public Animator animator;

    private float nextTimeToFire = 0f;

    void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        isReloading = true;

        if (isReloading)
        return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()

    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloadding", true);

        yield return new WaitForSeconds(2);

        animator.SetBool("Reloadding", false);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        ok.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fbsCam.transform.position, fbsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamge(damge);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }


        }

    }
}
