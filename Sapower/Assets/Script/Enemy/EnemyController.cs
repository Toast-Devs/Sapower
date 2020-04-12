using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public int quantasMoedasOMobDropa;
    public float tempoParaVirar;
    public float Velocidade;
    public float quaoParaCimaOPlayerVai;
    public bool comecarPelaDireita;
    public bool comecarPelaEsquerda;

    public GameObject CoinDropObj;
    private Rigidbody2D rb;
    public GameObject vida;
    public GameObject playerObject;
    public Rigidbody2D playerRB;
    public GameObject enemy;
    private Collider2D coll;
    private int qntvida;

    private bool direita; 
    private bool esquerda;
    private float tempo;

    // Start is called before the first frame update
    void Start()
    {

        CoinDropObj = GameObject.Find("player_real/CoinDropObj");
        vida = GameObject.Find("player_real/Contadores");
        playerObject = GameObject.Find("player_real");
        playerRB = playerObject.GetComponent<Rigidbody2D>();
        tempo = tempoParaVirar;
     

        if(comecarPelaDireita){
            direita = true;
            esquerda = false;
        }
        if(comecarPelaEsquerda){
            direita = false;
            esquerda = true;
        }
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Pé" && GetComponent<KnockBack>().backMovement == false){
            Morrer();
            CoinDropObj.GetComponent<MobsCoinDrop>().morreu = true;
            CoinDropObj.GetComponent<MobsCoinDrop>().mob = gameObject;
        }
        if(other.tag == "Player"){
            Matar();
        }
        
    }

    void Movimento(){
        if(direita && tempoParaVirar>0 && !esquerda){
            transform.localScale = new Vector2(1, 1);
            transform.Translate(new Vector3(Velocidade*Time.deltaTime, 0, 0), Space.Self);
            tempoParaVirar -= Time.deltaTime;
        }
        else if(esquerda && tempoParaVirar>0 && !direita){
            transform.localScale = new Vector2(-1, 1);
            transform.Translate(new Vector3(-Velocidade*Time.deltaTime, 0, 0),Space.Self);
            tempoParaVirar-= Time.deltaTime;
        }
        else{
            direita=!direita;
            esquerda=!esquerda;
            tempoParaVirar=tempo;
        }
    }

    void Matar(){

        //Mudar depois para tirar vida e reiniciar a fase
        //vou colocar destroy pra concept proof
        vida.GetComponent<Vidas>().NumeroDeVidas--;


    }

    void Morrer(){

        //vou colocar destroy pra concept proof
        playerRB.velocity = new Vector2(playerRB.velocity.x, quaoParaCimaOPlayerVai);

    }
}
