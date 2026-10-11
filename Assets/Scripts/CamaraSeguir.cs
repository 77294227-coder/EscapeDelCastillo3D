
using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    public Transform jugador;

    public Vector3 distancia = new Vector3(0, 5, -7);

    void LateUpdate()
    {
        if (jugador == null) return;

        transform.position = jugador.position + distancia;

        transform.LookAt(jugador.position + Vector3.up);
    }
}
