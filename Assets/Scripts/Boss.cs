using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour , IDamagable
{
    private HealthSystem healthSystem;
    public VolumeHealth healthIndicator;
    public int healthMax;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(healthMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
        healthIndicator.UpdateSprite(healthSystem.GetHealthPercentage());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //DealDamage(10);
    }
}
