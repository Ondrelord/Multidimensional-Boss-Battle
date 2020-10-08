using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooterHandler : MonoBehaviour
{
    public Pooler pool;

    private GameObject player;

    [SerializeField]
    private float shotCooldown = 5f;
    private float shotTimer = 5f;

    [SerializeField]
    private float shotSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        pool.init();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ShootHandler();
    }

    private void ShootHandler()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer < 0)
        {
            Vector2 dir = Utils.GetDirection(transform.position, player.transform.position);

            GameObject shot = pool.GetObject(transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(dir.normalized * shotSpeed, ForceMode2D.Impulse);

            shotTimer = shotCooldown;
        }
    }
}
