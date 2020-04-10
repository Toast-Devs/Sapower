using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFx : MonoBehaviour
{

    public GameObject Coinfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
