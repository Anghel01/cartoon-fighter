using UnityEngine;
public class playerMovement : MonoBehaviour
{
    public float speed = 5f; // establece la velocidad de movimiento del jugador a 5 unidades por segundo
    public float jumpForce = 10f; // establece la fuerza de salto del jugador a 10 unidades
    private Rigidbody2D rb; // referencia al componente Rigidbody2D del jugador, rigibody2d es un componente que permite aplicar física a un objeto en 2D, 
    // es private porque solo se usará dentro de esta clase
    private bool isGrounded; // variable booleana para verificar si el jugador está en el suelo, es private porque solo se usará dentro de esta clase, isGrounded es una variable que se utiliza para determinar si el jugador está tocando el suelo, lo que es necesario para permitir que el jugador salte solo cuando está en el suelo
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtiene el componente Rigidbody2D del jugador y lo asigna a la variable rb
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // obtiene el valor del eje horizontal (teclas A/D o flechas izquierda/derecha) y lo asigna a la variable moveX

        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y); // establece la velocidad horizontal del jugador multiplicando el valor de moveX por la velocidad y manteniendo la velocidad vertical actual

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //getkeydown detecta si se ha presionado la tecla espacio, y keycode.space es la tecla espacio, y isGrounded verifica si el jugador está en el suelo
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (moveX > 0) // si el jugador se mueve hacia la derecha (moveX es mayor que 0), se establece la escala local del jugador a (5, 5, 1) para que mire hacia la derecha
        {
            transform.localScale = new Vector3(5, 5, 1);
        }
        else if (moveX < 0) // si el jugador se mueve hacia la izquierda (moveX es menor que 0), se establece la escala local del jugador a (-5, 5, 1) para que mire hacia la izquierda
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }
}