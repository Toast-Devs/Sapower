using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinShow : MonoBehaviour
{
    int qntCoin;
    private Text text;
    public GameObject contador;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        contador = GameObject.Find("player/Contadores");
    }

    // Update is called once per frame
    void Update()
    {
        qntCoin = contador.GetComponent<Coins>().numeroDeCoins;
        text.text = qntCoin.ToString();
    }

   

}
