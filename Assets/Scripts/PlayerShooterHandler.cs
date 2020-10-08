using System.Collections;
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

    private void Update()
    {
        AimHandler();
        ShootHandler();
    }

    void AimHandler()
    {
        gunHandle.localPosition = MouseAimHandler.GetAim();

        float rotation = Vector2.SignedAngle(Vector2.right, gunHandle.localPosition);
        gunHandle.localEulerAngles = new Vector3(0, 0, rotation);

        if (Mathf.Abs(rotation) > 90)
            gunHandle.localScale = new Vector2(1, -1);
        else
            gunHandle.localScale = new Vector2(1, 1);
    }

    void ShootHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 dir = Utils.GetDirection(transform.position, gunHandle.position);

            GameObject shot = pool.GetObject(gunHandle.GetChild(0).position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(dir.normalized, ForceMode2D.Impulse);
        }
    }
}

