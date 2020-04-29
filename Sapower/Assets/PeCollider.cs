using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeCollider : MonoBehaviour
{

    public LayerMask ground;
    private bool noChao;
    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        noChao = false;
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Verificar quando ele encosta no chão
    void TocarChao()
    {

        if (coll.IsTouchingLayers(ground))
        {
            noChao = true;
        }
        else
        {
            noChao = false;
        }

    }


}
