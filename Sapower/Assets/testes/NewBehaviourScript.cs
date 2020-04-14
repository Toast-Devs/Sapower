using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        GameObject.Find("player_real").GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().SetBool("cutscene", false);
    }
}
