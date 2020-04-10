using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinShow : MonoBehaviour
{

    private Text text;
    public GameObject coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = GetComponent<Coins>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
