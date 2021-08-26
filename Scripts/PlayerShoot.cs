using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public GameObject grenade; 

    public float bulletSpeed;
    public float grenadeSpeed;

    public int currbulletCount;
    public int maxBulletCount; 
    public int grenadeCount; 

    public float currBulletTimer;
    public float maxBulletTimer = .5f;

    public float reloadTime; 

    public TextMeshProUGUI ammoCountUI;
    public Image[] grenadeIcons; 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && currbulletCount > 0)
        {
            if (currBulletTimer <= 0)
            {
                Shoot();
                currBulletTimer = maxBulletTimer; 
            }
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (grenadeCount > 0)
                ThrowGrenade();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        if(currBulletTimer > 0.0f)
            currBulletTimer -= Time.deltaTime; 
    }

    void Shoot()
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

        currbulletCount -= 1;
        ammoCountUI.text = currbulletCount.ToString() + "/" + maxBulletCount.ToString();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);

        currbulletCount = maxBulletCount;
        ammoCountUI.text = currbulletCount.ToString() + "/" + maxBulletCount.ToString(); 
    }

    void ThrowGrenade()
    {
        GameObject tempGrenade = Instantiate(grenade, transform.position, Quaternion.identity);

        tempGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * grenadeSpeed, ForceMode.VelocityChange);

        grenadeCount -= 1;

        grenadeIcons[grenadeCount].enabled = false; 
    }
}
