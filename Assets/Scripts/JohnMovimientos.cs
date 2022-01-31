using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovimientos : MonoBehaviour
{
    //creamos una variable global, es una referencia a Rigidbody2D
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    private Animator Animator;
    private float LastShoot;
    private int Health = 5;

    public float Speed;
    public float JumpForce;
    public GameObject balaPrefab;


    
    // Al principio del juego se ejecuta este codigo solo una vez
    void Start()
    {
        //esta funcion coge el Rigidbody2D
        Rigidbody2D=GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Es una funcion que se llama una vez cada frame, es donde va la logica del juego,vamos a poner todo lo que se tiene que ejecutar en cada frame
    void Update()
    {
        //En horizontal se van a almacenar valores tipo float, con esto vamos a obetener valores de -1 a 1 en funcion de ki que este pulsando
        //la persona en el teclado(tecla a=-1, tecla d=1 y si no pulsa ninguna tecla =0)
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }else Grounded= false;

        //Salto
        if(Input.GetKeyDown(KeyCode.W)&& Grounded){
            Jump();
        }

        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }


    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    
    private void FixedUpdate(){
        Rigidbody2D.velocity=new Vector2(Horizontal,Rigidbody2D.velocity.y);
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
