using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFx : MonoBehaviour
{
    public int coin = 0;
    public Text coinText;
    public GameObject Coinfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCoin")
        {
            DestroyObject(gameObject);
            coinText.text = coin.ToString();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
