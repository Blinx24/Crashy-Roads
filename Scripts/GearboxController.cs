using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearboxController
{
    [SerializeField] private int gear = 1;
    [SerializeField] private float speed = 0;
    [SerializeField] const int MIN_SPEED = 0;
    [SerializeField] const int MAX_SPEED = 120;

    private float oldSpeed = 0;
    private float refVel = 0;
    private float smoothSpeed = 1.5f;
    private float relMaxSpeed = MAX_SPEED;
    
    private AudioSource audioEngine;
    private Text txtGear = GameObject.Find("TxtGearbox").GetComponent<Text>();
    private Text txtVelocity = GameObject.Find("TxtVelocity").GetComponent<Text>();
    private Color txtColor = new Color(0.962f, 0.962f, 0.962f);
    
    private CarController carController = GameObject.Find("Car").GetComponent<CarController>();

    //Getters y Setters
    public int Gear
    {
        get {return gear; }
        set {gear = value; }
    }
    public float Speed
    {
        get {return speed; }
        set {speed = value; }
    }
    public int GetMaxSpeed
    {
        get {return MAX_SPEED; }
    }

    public GearboxController(AudioSource audioEngine_) {

        audioEngine = audioEngine_;
    }

    public void Update()
    {
        //Acelerar/frenar
        float inputVal = Input.GetAxis("Accelerate");
        float newSpeed = Mathf.Max(MIN_SPEED, inputVal*relMaxSpeed);

        speed = Mathf.SmoothDamp(speed, newSpeed, ref refVel, 1f);
        int roundSpeed = (int)Mathf.Round(speed);
        txtVelocity.text = roundSpeed.ToString()+" Km/h";

        audioEngine.pitch = Mathf.Lerp(0.1f, 1, speed/MAX_SPEED);

        //Cambio de marchas
        if (Input.GetButtonDown("GearUp")) {
            gear = Mathf.Min(gear + 1, 6);
            txtGear.text = gear.ToString()+"º";

            carController.UpdateTextColliders();
        }
        if (Input.GetButtonDown("GearDown")) {
            gear = Mathf.Max(1, gear - 1);
            txtGear.text = gear.ToString()+"º";

            carController.UpdateTextColliders();
        }

        switch(gear) {

            case 1: relMaxSpeed = 10; break;
            case 2: relMaxSpeed = 30; break;
            case 3: relMaxSpeed = 50; break;
            case 4: relMaxSpeed = 70; break;
            case 5: relMaxSpeed = 90; break;
            case 6: relMaxSpeed = MAX_SPEED; break;
        }

        //Color indicador
        if (speed >= relMaxSpeed - 0.5f) {

            txtVelocity.color = Color.red;
        }
        else {

            txtVelocity.color = txtColor;
        }
    }
}
