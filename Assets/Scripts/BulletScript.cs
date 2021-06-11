using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void Start()
    {
        float lifeTime = 0.08f * speed;
        Invoke("DestroyBullet", lifeTime);
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}