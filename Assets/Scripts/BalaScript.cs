using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;
    

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

   /* private void OnTriggerEnter2D(Collider2D collision){
        JohnMovimientos john =collision.GetComponent<JohnMovimientos>();
        DogeScript doge=collision.GetComponent<DogeScript>();
        if (doge != null)
        {
            doge.Hit();
        }
        if (john != null)
        {
            john.Hit();
        }
        DestroyBullet();

    }*/

}
