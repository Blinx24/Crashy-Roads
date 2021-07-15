using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController
{
    private RectTransform Rect;
    private GearboxController Gearbox;
    [SerializeField] private float fuel;
    [SerializeField] private float fuelSpeed = 0.05f;

    private bool stop = false;

    private const float MAX_FUEL = 100;

    public float Fuel
    {
        get {return fuel; }
        set {fuel = value; }
    }
    public float GetMaxFuel
    {
        get {return MAX_FUEL; }
    }
    public bool Stop
    {
        get {return stop; }
        set {stop = value; }
    }

    // Start is called before the first frame update
    public FuelController()
    {
        Rect = GameObject.Find("IndFuel").GetComponent<RectTransform>();
        Gearbox = GameObject.Find("Car").GetComponent<CarController>().GearBox;

        fuel = MAX_FUEL;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!stop) {

            if (Gearbox.Speed >= 0.1) {
                //Gasto gasolina
                float speed = Mathf.Clamp(Gearbox.GetMaxSpeed - Gearbox.Speed, 10, Gearbox.GetMaxSpeed);
                fuel = Mathf.Max(0, fuel - speed*fuelSpeed*Time.deltaTime);
            }
        }

        //Indicador
        Rect.localScale = new Vector2(1, fuel/MAX_FUEL);
    }
}
