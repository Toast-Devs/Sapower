using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsCoinDrop : MonoBehaviour
{

    public bool morreu;




    public GameObject coinObj;
    public GameObject mob;
    


    private int contador;
    // Start is called before the first frame update
    void Start()
    {
        morreu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(morreu){
            contador++;
        }
        if(contador>20){
            Destroy(mob);
            for(int contador2=0; contador2<mob.GetComponent<EnemyController>().quantasMoedasOMobDropa; contador2++){
                Instantiate(coinObj, new Vector3(mob.transform.position.x, mob.transform.position.y, mob.transform.position.z), new Quaternion(mob.transform.rotation.x,
                mob.transform.rotation.y, mob.transform.rotation.z, mob.transform.rotation.w));
            }
            morreu = false;
        }
    }
}
