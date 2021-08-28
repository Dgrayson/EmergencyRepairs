using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float timer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.tag == "EnemyBullet" && collider.gameObject.tag == "Enemy")
        { }
        else
            Destroy(gameObject);
    }
}