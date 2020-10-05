using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private HealthSystem healthSystem;

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
}
