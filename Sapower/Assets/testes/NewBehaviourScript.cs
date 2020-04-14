using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private bool shake;
    [SerializeField] private bool zoom;
    [SerializeField] private bool zoomOut;
    [SerializeField] private float tempoParaOZoomOut;
    private float tempo2;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject counterVida;
    [SerializeField] private GameObject counterCoin;
    [SerializeField] private GameObject coinfx;
    // Start is called before the first frame update
    void Start()
    {
        tempo2=tempoParaOZoomOut;
        shake=false;
        zoom=false;
        zoomOut=false;
        ui.GetComponent<Canvas>().enabled = false;
        coinfx.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(zoom){
            GameObject.Find("Camera").GetComponent<Camera>().orthographicSize = 2;
            ui.GetComponent<Canvas>().enabled =false;
            coinfx.SetActive(false);


        }
        if(shake){
            CameraShake.instance.StartShake(0.2f, 0.3f);
        }
        if(zoomOut){
            if(GameObject.Find("Camera").GetComponent<Camera>().orthographicSize<5){
                GameObject.Find("Camera").GetComponent<Camera>().orthographicSize += 0.1f;
            }
            else if(GameObject.Find("Camera").GetComponent<Camera>().orthographicSize>4){
                zoom = false;
                GameObject.Find("Camera").GetComponent<Camera>().orthographicSize = 5;
                Instantiate(player);
                GameObject.Find("player_real(Clone)").transform.position = transform.position;
                GameObject.Find("player_real(Clone)").name = "player_real";
                ui.GetComponent<Canvas>().enabled = true;
                coinfx.SetActive(true);
                counterVida.GetComponent<VidaShow>().contador = GameObject.Find("player_real/Contadores");
                counterCoin.GetComponent<CoinShow>().contador = GameObject.Find("player_real/Contadores");
                GameObject.Find("Camera").GetComponent<CameraFollow>().target = GameObject.Find("player_real").transform;
                Destroy(gameObject);
            }

        }
    }
}
