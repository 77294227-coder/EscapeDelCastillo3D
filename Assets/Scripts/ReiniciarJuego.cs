
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    public void Reiniciar()
    {
        RecolectarLlave.llavesRecogidas = 0;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
