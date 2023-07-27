using UnityEngine;

public class StairController : MonoBehaviour
{
    public float climbSpeed = 5f; // Velocidad de subida o bajada en la escalera

    private bool isOnStairs = false; // Indica si el jugador est� en la escalera

    private Rigidbody2D rb;

    public GameObject character;

    private void Awake()
    {
        rb = character.GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnStairs = true;
            rb.gravityScale = 0f; // Desactivar la gravedad mientras est� en la escalera
            rb.velocity = Vector2.zero; // Detener cualquier movimiento actual del jugador
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnStairs = false;
            rb.gravityScale = 1f; // Restaurar la gravedad al salir de la escalera
        }
    }

    private void Update()
    {
        if (isOnStairs)
        {
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput > 0) // Si el jugador presiona la tecla arriba
            {
                // Mover el jugador hacia arriba en la escalera
                rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            }
            else if (verticalInput < 0) // Si el jugador presiona la tecla abajo
            {
                // Mover el jugador hacia abajo en la escalera
                rb.velocity = new Vector2(rb.velocity.x, -climbSpeed);
            }
            else
            {
                // Si el jugador no presiona ninguna tecla, mantenerlo quieto en la escalera
                rb.velocity = Vector2.zero;
            }
        }
    }
}
