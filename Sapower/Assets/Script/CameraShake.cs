using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    private float shakeTime;
    private float shakePower;
    private float shakeFade;
    private float shakeRotation;

    public static CameraShake instance;
    public float rotationMultiplier = 15;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFade * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));

    }

    public void StartShake(float lenght, float power)
    {
        shakeTime = lenght;
        shakePower = power;

        shakeFade = power / lenght;

        shakeRotation = power * rotationMultiplier;
    }
}
