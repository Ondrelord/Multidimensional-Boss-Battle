﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterHandler : MonoBehaviour
{
    public Pooler pool;

    public Transform gunHandle;
    void Start()
    {
        pool.init();
    }

    private void FixedUpdate()
    {
        gunHandle.localPosition = MouseAimHandler.GetAim();

        float rotation = Vector2.SignedAngle(Vector2.right, gunHandle.localPosition);
        gunHandle.localEulerAngles = new Vector3(0, 0, rotation);

        if (Mathf.Abs(rotation) > 90) 
            gunHandle.localScale = new Vector2( 1, -1);
        else
            gunHandle.localScale = new Vector2(1, 1);
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = Utils.GetDirection(transform.position, mousePos);
            
            GameObject shot = pool.GetObject(transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(dir.normalized, ForceMode2D.Impulse);
        }
    }
}
