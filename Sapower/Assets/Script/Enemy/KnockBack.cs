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
    private Rigidbody2D rb;
    public bool backMovement;
    private float knockbackLenght2;
    public int qntVida;
    public GameObject contador;

    private PlayerController controller;
    

    // Start is called before the first frame update
    void Start()
    {
       playerObj = GameObject.Find("player_real");
        controller = playerObj.GetComponent<PlayerController>();
        backMovement = false;
        knockbackLenght2 = knockbackLenght;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !(collision.gameObject.tag == "Pé") && !(collision.gameObject.tag == "PlayerCoin"))
        {
            //Cancelar o movimento do player
            controller.movementCancel = true;

            //Aplicaar o movimento de knockback no player
            playerObj.GetComponent<Rigidbody2D>().velocity = new Vector2(knockback * (playerObj.transform.position.x - transform.position.x), playerObj.GetComponent<Rigidbody2D>().velocity.y);

            //balançar a camera
            CameraShake.instance.StartShake(0.1f, 0.2f);
         
            //Voltar com o movimento do player após um certo tempo
            backMovement = true;
        }
        
    }
    

    public void BackMovement()
    {
        if (backMovement == true)
        {
            knockbackLenght -= Time.deltaTime;

            if (knockbackLenght <= 0)
            {
                controller.movementCancel = false;
                backMovement = false;
                knockbackLenght = knockbackLenght2;
            }
        }
    }

    void Update()
    {
        BackMovement();
    }
}
