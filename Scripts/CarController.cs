using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation.Examples;
using TMPro;


public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] [Range(0, 100)] private float horMovementSpeed;
    [SerializeField] [Range(0, 1)] private float scaleVerticalSpeed;
    [SerializeField] PathFollower pathFollower;
    [SerializeField] private AudioManager Audio;
    [SerializeField] private AudioSource audioEngine;
    [SerializeField] private Transform Obstacles;

    private GearboxController gearbox;
    private FuelController fuel;
    private Transform Car;
    [SerializeField] private ObstacleController[] obsController;
    [SerializeField] private TextMeshPro[] obsText;

    private const float MAX_HORIZONTAL_MOVE = 5;
    private float distLimits = 0;

    private bool failObstacle = false;

    //Variables jugador
    private Text txtScore;
    private float score = 0;
    private bool startGame = false;

    //Getters y setters
    public GearboxController GearBox
    {
        get {return gearbox; }
        set {gearbox = value; }
    }

    public FuelController Fuel
    {
        get {return fuel; }
        set {fuel = value; }
    }

    public float Score
    {
        get {return score; }
        set {score = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        gearbox = new GearboxController(audioEngine);
        Fuel = new FuelController();
        Car = GameObject.Find("CarModel").GetComponent<Transform>();

        txtScore = GameObject.Find("TxtScore").GetComponent<Text>();

        UpdateTextColliders();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame) {
            //Updates
            gearbox.Update();
            Fuel.Update();
            txtScore.text = Score.ToString();

            //Eventos
            if (failObstacle) {
                gearbox.Speed = 0;
                Rotate();
            }
            
        }
    }

    private void FixedUpdate() {

        if (startGame) {
            float horSpd;
            if (!failObstacle) {
                //Velocidad horizontal (al girar el volante)
                horSpd = Input.GetAxis("Horizontal")*horMovementSpeed;
                distLimits = Mathf.Clamp(distLimits + horSpd*Time.deltaTime, -MAX_HORIZONTAL_MOVE, MAX_HORIZONTAL_MOVE);
            }
            else {

                horSpd = 0;
            }

            if (distLimits < MAX_HORIZONTAL_MOVE && distLimits > -MAX_HORIZONTAL_MOVE && !failObstacle) {

                rb.velocity = new Vector3(transform.right.x*horSpd, rb.velocity.y, transform.right.z*horSpd);
            }
            else {

                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }

            //Velocidad vertical (acelerar/frenar/cambiar marcha)
            pathFollower.speed = gearbox.Speed*scaleVerticalSpeed;
        }
    }

    private void Rotate() {
        //Quaternion euler = Quaternion.Euler(1, 1, 1);
        Car.Rotate(0,600*Time.deltaTime,0);
    }

    public IEnumerator FailObstacle() {

        Quaternion forwardRot = Car.rotation;
        failObstacle = true;
        fuel.Stop = true;
        Audio.Play("sfx_drift");
        yield return new WaitForSeconds(1.25f);
        failObstacle = false;
        fuel.Stop = false;
        Car.rotation = forwardRot;
        Audio.SfxSource[1].Stop();
    }

    public void StartGame() {

        startGame = true;
    }

    public void UpdateTextColliders() {

        //Color letras obstáculos
        for (int i = 0; i < obsText.Length; i++) {

            if (obsController[i].GearLevel >= GearBox.Gear) {
                obsText[i].color = Color.green;
            }
            else if (obsController[i].GearLevel == GearBox.Gear) {

                obsText[i].color = Color.green;
            } else {
                obsText[i].color = Color.red;
            }
            
        }
    }

}
