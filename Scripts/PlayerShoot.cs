using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public float bulletSpeed;

    public float currBulletTimer;
    public float maxBulletTimer = .5f; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if (currBulletTimer <= 0)
            {
                Shoot();
                currBulletTimer = maxBulletTimer; 
            }
        }

        if(currBulletTimer > 0.0f)
            currBulletTimer -= Time.deltaTime; 
    }

    void Shoot()
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse); 
    }
}
