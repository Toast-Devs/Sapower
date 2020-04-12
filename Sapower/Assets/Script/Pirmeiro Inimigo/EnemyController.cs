﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public int quantasMoedasOMobDropa;
    public int tempoParaVirar;
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

    private bool morreu;
    private bool direita; 
    private bool esquerda;
    private int contador;
    private int contadorDireita;
    private int contadorEsquerda;

    // Start is called before the first frame update
    void Start()
    {

        CoinDropObj = GameObject.Find("player_real/CoinDropObj");
        vida = GameObject.Find("player_real/Contadores");
        playerObject = GameObject.Find("player_real");
        playerRB = playerObject.GetComponent<Rigidbody2D>();
        
     

        if(comecarPelaDireita){
            direita = true;
            esquerda = false;
        }
        if(comecarPelaEsquerda){
            direita = false;
            esquerda = true;
        }
        contador=0;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        contadorDireita = 0;

        contadorEsquerda=tempoParaVirar;
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Pé"){
            Morrer();
            CoinDropObj.GetComponent<MobsCoinDrop>().morreu = true;
            CoinDropObj.GetComponent<MobsCoinDrop>().mob = gameObject;
        }
        if(other.tag == "Player"){
            Matar();
        }
        
    }

    void Movimento(){
        if(direita && contador<tempoParaVirar){
            transform.localScale = new Vector2(1, 1);
            rb.velocity = new Vector2(Velocidade, rb.velocity.y);
            contador++;
        }
        if(esquerda && contador<tempoParaVirar){
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = new Vector2(-Velocidade, rb.velocity.y);
            contador++;
        }
        if(contador>=tempoParaVirar){
            direita=!direita;
            esquerda=!esquerda;
            contador=0;
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
