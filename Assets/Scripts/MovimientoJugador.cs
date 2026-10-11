
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float gravedad = -9.81f;

    private CharacterController controlador;
    private float velocidadVertical;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movimiento usando WASD o las flechas
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            vertical = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            vertical = -1f;

        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        // Girar hacia donde camina
        if (direccion.sqrMagnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(direccion);
        }

        // Aplicar gravedad
        if (controlador.isGrounded && velocidadVertical < 0f)
            velocidadVertical = -2f;

        velocidadVertical += gravedad * Time.deltaTime;

        Vector3 movimiento = direccion * velocidad;
        movimiento.y = velocidadVertical;

        controlador.Move(movimiento * Time.deltaTime);
    }
}

