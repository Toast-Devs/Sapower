using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockback;
    public float knockbackLenght;
    public float knockbackCount;
    public bool knockFromRight;
    private GameObject playerObj;


    private void movement() { playerObj.GetComponent<PlayerController>().Movement(); }
    

    // Start is called before the first frame update
    void Start()
    {
       playerObj = GameObject.Find("player_real");
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackCount <= 0)
        {
            movement();
        }
    }
}
