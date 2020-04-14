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
    // Start is called before the first frame update
    void Start()
    {
        tempo2=tempoParaOZoomOut;
        shake=false;
        zoom=false;
        zoomOut=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(zoom){
            GameObject.Find("Camera").GetComponent<Camera>().orthographicSize = 2;

        }
        if(shake){
            CameraShake.instance.StartShake(0.2f, 0.3f);
            print("a");
        }
        if(zoomOut){
            if(GameObject.Find("Camera").GetComponent<Camera>().orthographicSize<5){
                GameObject.Find("Camera").GetComponent<Camera>().orthographicSize += 0.1f;
            }
            else if(GameObject.Find("Camera").GetComponent<Camera>().orthographicSize>4){
                GameObject.Find("Camera").GetComponent<Camera>().orthographicSize = 5;
                Instantiate(player);
                GameObject.Find("player_real(Clone)").transform.position = transform.position;
                GameObject.Find("Camera").GetComponent<CameraFollow>().target = GameObject.Find("player_real(Clone)").transform;
                Destroy(gameObject);
            }

        }
    }
}
