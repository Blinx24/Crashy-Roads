using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    private CarController Car;
    private GoalIndicator GoalInd;
    private Timer Timer;
    [SerializeField] private Transform PauseMenu;
    [SerializeField] private EndGameController EndGame;

    private AudioManager Audio;

    [SerializeField] private Image imgMusicM;
    [SerializeField] private Image imgSfxM;
    [SerializeField] private Image imgMusicP;
    [SerializeField] private Image imgSfxP;
    [SerializeField] private Image fuelIndicator;
    [SerializeField] private Sprite sprMusic0;
    [SerializeField] private Sprite sprMusic1;
    [SerializeField] private Sprite sprSfx0;
    [SerializeField] private Sprite sprSfx1;

    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button FinishButton;

    private bool muteMusic = false;
    private bool muteSfx = false;

    private bool pause = false;
    private bool finish = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Car = GameObject.Find("Car").GetComponent<CarController>();
        GoalInd = GameObject.Find("IndCar").GetComponent<GoalIndicator>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
        fuelIndicator = GameObject.Find("IndFuel").GetComponent<Image>();
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!finish) {

            if(Car.Fuel.Fuel <= 20) {
                fuelIndicator.color = Color.red;
            } else {
                fuelIndicator.color = Color.yellow;
            }

            //Condiciones de derrota
            //Se queda sin gasolina
            if (Car.Fuel.Fuel <= 0) {

                Debug.Log("HAS PERDIDO :c");
                Defeat();
            }

            //Se acaba el tiempo (...)
            if (Timer.Timertime == 0) {

                Debug.Log("HAS PERDIDO :c");
                Defeat();
            }

            //Condición de victoria
            //Llegar a la meta
            if (GoalInd.Progress >= 1-0.005) {

                Debug.Log("HAS GANADO :D");
                Victory();
            }

            //Menú de pausa
            if (Input.GetButtonDown("Pause")) {

                pause = !pause;
                Pause(pause);
            }
        }
    }

    public void Victory() {

        EndGame.gameObject.SetActive(true);
        Time.timeScale = 0f;
        // Texto principal
        EndGame.TextEndGame.text = "YOU WIN!";
        EndGame.TextEnd2.text = "Congratulations!";

        // Puntuación
        Car.Score = Mathf.Ceil(Car.Score + (Timer.Timertime * 10));
        EndGame.TextScoreEnd.text = "Score: " + Car.Score.ToString();

        FinishButton.Select();

        Audio.StopAll();
        Audio.Play("mus_win");

        finish = true;
    }

    public void Defeat() {

        EndGame.gameObject.SetActive(true);
        Time.timeScale = 0f;
        
        // Texto
        EndGame.TextEndGame.text = "YOU LOSE";
        if(Car.Fuel.Fuel <= 0) {
            EndGame.TextEnd2.text = "Empty fuel";
        } else if (Timer.Timertime == 0) {
            EndGame.TextEnd2.text = "Time´s Up";
        }

        // Puntuación
        EndGame.TextScoreEnd.text = "Score: " + Car.Score.ToString();

        FinishButton.Select();
        
        Audio.StopAll();
        Audio.Play("mus_defeat");

        finish = true;
    }

    private void Pause(bool b) {

        PauseMenu.gameObject.SetActive(b);

        if (b) {

            Time.timeScale = 0;
            //if (EventSystem.current.currentSelectedGameObject != ResumeButton.gameObject)
            ResumeButton.Select();
            Audio.PauseAll();
        }
        else {

            Time.timeScale = 1;
            Audio.ResumeAll();
        }
    }

    public void Resume() {

        pause = !pause;
        Pause(false);
    }

    public void ReturnMenu() {

        EndGame.ReturnMenu();
    }

    public void MuteMusic() {

        muteMusic = !muteMusic;

        if (muteMusic) {

            imgMusicM.sprite = sprMusic1;
            imgMusicP.sprite = sprMusic1;
            Audio.MuteMusic();
        }
        else {

            imgMusicM.sprite = sprMusic0;
            imgMusicP.sprite = sprMusic0;
            Audio.DesMuteMusic();
        }
    }

    public void MuteSfx() {

        muteSfx = !muteSfx;

        if (muteSfx) {

            imgSfxM.sprite = sprSfx1;
            imgSfxP.sprite = sprSfx1;
            Audio.MuteSfx();
        }
        else {

            imgSfxM.sprite = sprSfx0;
            imgSfxP.sprite = sprSfx0;
            Audio.DesMuteSfx();
        }
    }
}
