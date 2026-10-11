
using UnityEngine;
using TMPro;

public class ContadorLlaves : MonoBehaviour
{
    public TextMeshProUGUI textoLlaves;

    void Update()
    {
        if (textoLlaves != null)
        {
            textoLlaves.text = "Llaves: " +
                RecolectarLlave.llavesRecogidas + "/3";
        }
    }
}
