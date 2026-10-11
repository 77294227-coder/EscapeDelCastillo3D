
using UnityEngine;

public class RecolectarLlave : MonoBehaviour
{
    public static int llavesRecogidas = 0;

    public AudioClip sonidoLlave;

    void OnTriggerEnter(Collider otro)
    {
        if (!otro.CompareTag("Player")) return;

        llavesRecogidas++;

        if (sonidoLlave != null)
        {
            GameObject audioObjeto = new GameObject("SonidoLlave");
            AudioSource audio = audioObjeto.AddComponent<AudioSource>();

            audio.clip = sonidoLlave;
            audio.spatialBlend = 0f;
            audio.volume = 1f;
            audio.Play();

            Destroy(audioObjeto, sonidoLlave.length + 0.2f);
        }

        Debug.Log("Llaves recogidas: " + llavesRecogidas);

        gameObject.SetActive(false);
    }
}
