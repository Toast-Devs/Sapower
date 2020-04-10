using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFx : MonoBehaviour
{
    public GameObject Coinfx;
    private int qntCoin;
    public GameObject coinCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCoin")
        {

            qntCoin++;
            DestroyObject(gameObject);
            PlayFx();


        }
    }

    void PlayFx()
    {
        GameObject Fx = (GameObject)Instantiate(Coinfx);

        Fx.transform.position = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        qntCoin = coinCounter.GetComponent<CoinCounter>().quantidadeCoin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
