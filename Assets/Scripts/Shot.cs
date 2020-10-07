using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage;

    public int GetDamgage() => damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damageable = collision.gameObject.GetComponent<IDamagable>();

        if (damageable != null)
            damageable.DealDamage(damage);

        gameObject.SetActive(false);
    }
}
