
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    public Transform jugador;
    public GameObject textoVictoria;

    public float distanciaActivacion = 3.5f;

    private bool puertaAbierta = false;
    private bool ganado = false;

    void Update()
    {
        if (jugador == null || ganado) return;

        float distancia = Vector3.Distance(
            transform.position, jugador.position
        );

        // Abrir la puerta cuando tenga las 3 llaves
        if (!puertaAbierta &&
            RecolectarLlave.llavesRecogidas >= 3 &&
            distancia <= distanciaActivacion)
        {
            puertaAbierta = true;

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }

        // Ganar cuando cruce la puerta
        if (puertaAbierta &&
            jugador.position.z >= 14f)
        {
            ganado = true;

            if (textoVictoria != null)
                textoVictoria.SetActive(true);

            MovimientoJugador movimiento =
                jugador.GetComponent<MovimientoJugador>();

            if (movimiento != null)
                movimiento.enabled = false;

            Debug.Log("¡HAS ESCAPADO DEL CASTILLO!");
        }
    }
}
