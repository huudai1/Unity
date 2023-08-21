using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public float range = 100f;

    public GameObject shotOrigin;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(shotOrigin.transform.position, shotOrigin.transform.forward, out hit, range))
        {
            Debug.DrawLine(shotOrigin.transform.position, hit.point, Color.red, 10f);
        }

    }
}
