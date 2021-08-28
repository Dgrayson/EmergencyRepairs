using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor; 

public class Player : MonoBehaviour
{
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    public float SystemRepairSpeed { get => systemRepairSpeed; set => systemRepairSpeed = value; }
    public Rigidbody Body { get => body; set => body = value; }

    [SerializeField]
    private float systemRepairSpeed = 10;

    private Rigidbody body;

    [Header("Health Settings")]
    [SerializeField]
    private float currentHealth = 100.0f;
    
    [SerializeField]
    private float maxHealth = 100.0f;
    
    [SerializeField]
    private Image healthUI;

    private bool isInvuln = false; 
    private float invulnTimer = 3.0f;
    private float maxInvulnTimer = 3.0f; 



    
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null || _instance != this)
            _instance = this;

        Body = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 4.0f)
        {
            Body.velocity = new Vector3(Body.velocity.x, 0.0f, Body.velocity.z);
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

    private void Die()
    {

    }
    public void UpdateRepairSpeed(float repairSpeed)
    {
        SystemRepairSpeed = repairSpeed; 
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
