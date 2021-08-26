using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor; 

public class Player : MonoBehaviour
{
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    public float systemRepairSpeed = 10;

    public Rigidbody body;

    [Header("Health Settings")]
    public float currentHealth = 100.0f;
    public float maxHealth = 100.0f;
    public Image healthUI;

    public bool isInvuln = false; 
    public float invulnTimer = 3.0f;
    public float maxInvulnTimer = 3.0f; 

    
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null || _instance != this)
            _instance = this;

        body = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 4.0f)
        {
            body.velocity = new Vector3(body.velocity.x, 0.0f, body.velocity.z);
            transform.position = new Vector3(transform.position.x, 3.999f, transform.position.z);
        }

        if (isInvuln)
        {
            invulnTimer -= Time.deltaTime;
            if(invulnTimer <= 0)
            {
                ToggleInvuln();
                invulnTimer = maxInvulnTimer; 
            }
        }

        if (currentHealth <= 0)
            Die(); 
    }

    public void UpdateRepairSpeed(float repairSpeed)
    {
        systemRepairSpeed = repairSpeed; 
    }

    public void TakeDamage(int damage)
    {
        if (!isInvuln)
        {
            currentHealth -= damage;
            UpdateHealthUI();
        }
    }

    public void HealDamage(int heal)
    {
        currentHealth += heal;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthUI(); 
    }

    private void UpdateHealthUI()
    {
        healthUI.rectTransform.sizeDelta = new Vector2(200.0f * (currentHealth / 100.0f), healthUI.rectTransform.sizeDelta.y);
    }

    public void ToggleInvuln()
    {
        isInvuln = !isInvuln; 
    }
}
