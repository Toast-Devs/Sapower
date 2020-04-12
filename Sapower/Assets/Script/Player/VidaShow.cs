using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaShow : MonoBehaviour
{

    private Text texto;
    private int qntVida;
    public GameObject contador;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        contador = GameObject.Find("player_real/Contadores");
    }

    // Update is called once per frame
    void Update()
    {
        qntVida = contador.GetComponent<Vidas>().NumeroDeVidas;
        texto.text = qntVida.ToString();
    }
}
