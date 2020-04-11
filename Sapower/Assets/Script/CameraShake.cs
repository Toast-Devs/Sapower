using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeTime;
    public float shakePower;
    public float shakeFade;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            StartShake(0.2f, 0.3f);
        }
    }

    private void LateUpdate()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0);

            shakePower = Mathf.MoveTowards(shakePower, 0, shakeFade * Time.deltaTime);
        }
    }

    public void StartShake(float lenght, float power)
    {
        shakeTime = lenght;
        shakePower = power;

        shakeFade = power / lenght;
    }
}
