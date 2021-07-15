using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate() {
        //Quaternion euler = Quaternion.Euler(1, 1, 1);
        transform.Rotate(0,100*Time.deltaTime,0);
    }
}
