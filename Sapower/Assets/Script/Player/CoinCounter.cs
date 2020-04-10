using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int quantidadeCoin;


    // Start is called before the first frame update
    void Start()
    {
        quantidadeCoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print(quantidadeCoin);
    }
}
