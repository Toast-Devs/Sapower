using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinFX : MonoBehaviour
{
    public GameObject CoinFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayFX()
    {
        GameObject explosion = (GameObject)Instantiate(CoinFX);

        explosion.transform.position = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            PlayFX();
        }
    }

    

}
