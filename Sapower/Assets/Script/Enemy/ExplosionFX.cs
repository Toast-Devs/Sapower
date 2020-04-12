using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFX : MonoBehaviour
{

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pé")
        {


            PlayFx();
            CameraShake.instance.StartShake(0.2f, 0.3f);


        }
    }

    void PlayFx()
    {
        GameObject Fx = (GameObject)Instantiate(Explosion);

        Fx.transform.position = transform.position;

    }
}
