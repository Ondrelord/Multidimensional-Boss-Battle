using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterHandler : MonoBehaviour
{
    public Pooler pool;
    void Start()
    {
        pool.init();
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
