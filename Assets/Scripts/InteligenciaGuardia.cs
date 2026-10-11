
using UnityEngine;

public class InteligenciaGuardia : MonoBehaviour
{
    public Transform jugador;
    public GameObject textoDerrota;
    public GameObject botonReintentar;

    public float velocidad = 2f;
    public float distanciaDeteccion = 8f;
    public float distanciaCaptura = 1.3f;

    private Vector3 puntoA = new Vector3(-6, 1, 3);
    private Vector3 puntoB = new Vector3(6, 1, 3);
    private Vector3 destino;

    private bool terminado = false;
    private bool persiguiendo = false;
    private float siguienteRevision = 0f;

    void Start()
    {
        destino = puntoB;
    }

    void Update()
    {
        if (jugador == null || terminado) return;

        float distanciaCapturaActual =
            Vector3.Distance(transform.position, jugador.position);

        // Comprobar si alcanzó al jugador
        if (distanciaCapturaActual <= distanciaCaptura)
        {
            terminado = true;

            if (textoDerrota != null)
                textoDerrota.SetActive(true);

            if (botonReintentar != null)
                botonReintentar.SetActive(true);

            MovimientoJugador movimiento =
                jugador.GetComponent<MovimientoJugador>();

            if (movimiento != null)
                movimiento.enabled = false;

            return;
        }

        // Optimización: actualizar detección cada 0.2 segundos
        if (Time.time >= siguienteRevision)
        {
            siguienteRevision = Time.time + 0.2f;
            persiguiendo =
                distanciaCapturaActual <= distanciaDeteccion;
        }

        if (persiguiendo)
        {
            MoverHacia(jugador.position);
        }
        else
        {
            MoverHacia(destino);

            if (Vector3.Distance(transform.position, destino) < 0.3f)
            {
                destino = destino == puntoA ? puntoB : puntoA;
            }
        }
    }

    void MoverHacia(Vector3 objetivo)
    {
        objetivo.y = transform.position.y;

        Vector3 direccion = objetivo - transform.position;

        if (direccion.sqrMagnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(direccion);

            transform.position = Vector3.MoveTowards(
                transform.position,
                objetivo,
                velocidad * Time.deltaTime
            );
        }
    }
}
