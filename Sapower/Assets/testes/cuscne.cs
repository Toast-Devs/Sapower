using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuscne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("player_cutscene").GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            
        GameObject.Find("player_cutscene").GetComponent<SpriteRenderer>().enabled = true;
        other.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("player_cutscene").GetComponent<Animator>().SetBool("cutscene", true);
        Destroy(gameObject);

        }
    }

}
