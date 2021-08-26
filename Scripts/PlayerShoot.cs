using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Ammo Prefabs")]
    public GameObject bullet;
    public GameObject grenade; 

    [Header("Ammo Speed")]
    public float bulletSpeed;
    public float grenadeSpeed;

    [Header("Ammo Count")]
    public int currbulletCount;
    public int maxBulletCount; 
    public int grenadeCount; 

    [Header("Ammo Timers")]
    public float currBulletTimer;
    public float maxBulletTimer = .5f;
    public float reloadTime; 

    [Header("Ammo UI")]
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
        UpdateAmmoText();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);

        currbulletCount = maxBulletCount;
        UpdateAmmoText(); 
    }

    void ThrowGrenade()
    {
        GameObject tempGrenade = Instantiate(grenade, transform.position, Quaternion.identity);

        tempGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * grenadeSpeed, ForceMode.VelocityChange);

        grenadeCount -= 1;

        grenadeIcons[grenadeCount].enabled = false; 
    }

    public void RefillAmmo()
    {
        currbulletCount = maxBulletCount;
        UpdateAmmoText();
    }

    public void RefillGrenade()
    {
        grenadeCount++;

        grenadeIcons[grenadeCount].enabled = true; 
    }

    private void UpdateAmmoText()
    {
        ammoCountUI.text = currbulletCount.ToString() + "/" + maxBulletCount.ToString();
    }
}
