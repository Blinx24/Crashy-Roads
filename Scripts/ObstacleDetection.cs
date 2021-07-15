using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleDetection : MonoBehaviour
{
    private CarController Car;
    private AudioManager Audio;
    // Start is called before the first frame update
    void Start()
    {
        Car = GameObject.Find("Car").GetComponent<CarController>();
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Obstacle") {

            ObstacleController obstacle = other.transform.parent.gameObject.GetComponent<ObstacleController>();

            if (obstacle.GearLevel >= Car.GearBox.Gear) {

                //Si estás en la marcha correcta, se rompe y ganas puntos
                Destroy(other.transform.parent.gameObject);
                //Ganar puntos
                if(obstacle.GearLevel == Car.GearBox.Gear){
                    Car.Score += 60;
                } else {
                    Car.Score += 30;
                }
                
                Audio.Play("sfx_correct");
            }
            else {

                //Si no estás en la marcha correcta, se rompe, te haces daño y pierdes velocidad
                StartCoroutine(Car.FailObstacle());
                //Hacer daño (bajar gasolina) (...)
                Car.Fuel.Fuel = Mathf.Max(0, Car.Fuel.Fuel - Car.Fuel.GetMaxFuel*0.1f);
                //Perder puntos
                Car.Score -= 10;
                Destroy(other.transform.parent.gameObject);

            }
        }

        if (other.tag == "Fuel") {

            Car.Fuel.Fuel = Mathf.Min(Car.Fuel.Fuel + Car.Fuel.GetMaxFuel*0.35f, Car.Fuel.GetMaxFuel);
            Destroy(other.transform.gameObject);
            Audio.Play("sfx_grabFuel");
        }
    }
}
