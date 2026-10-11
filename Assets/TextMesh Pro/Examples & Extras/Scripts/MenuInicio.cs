
using UnityEngine;

public class MenuInicio : MonoBehaviour
{
    public GameObject botonJugar;
    public GameObject tituloJuego;
    public MovimientoJugador jugador;

    void Start()
    {
        Time.timeScale = 0f;

        if (jugador != null)
            jugador.enabled = false;
    }

    public void Jugar()
    {
        Time.timeScale = 1f;

        if (jugador != null)
            jugador.enabled = true;

        if (botonJugar != null)
            botonJugar.SetActive(false);

        if (tituloJuego != null)
            tituloJuego.SetActive(false);
    }
}
