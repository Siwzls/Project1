using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float hp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }
    public void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy(gameObject);
    }
}
