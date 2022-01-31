using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeScript : MonoBehaviour
{
     public Transform John;
     public GameObject balaPrefab;

     private float LastShoot;
     private int Health = 3;

     
   
    // Update is called once per frame
    void Update()
    {
         Vector3 direction = John.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        
        float distance = Mathf.Abs(John.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }
     private void Shoot()
    {
         Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bala = Instantiate(balaPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }

     public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
    
}
