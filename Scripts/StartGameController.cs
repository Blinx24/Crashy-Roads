using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private Transform Follower;
    [SerializeField] private Transform GameController;
    [SerializeField] private Transform Hud;
    [SerializeField] private Transform CameraMenu;
    [SerializeField] private Transform CameraGame;
    [SerializeField] private Transform ControlsTuto;

    [SerializeField] private CarController Car;
    [SerializeField] private AudioManager Audio;
    [SerializeField] private Timer Timer;

    private bool controlsTuto = false;
    private bool muteMusic = false;
    private bool muteSfx = false;

    [SerializeField] private Image imgMusic;
    [SerializeField] private Image imgSfx;
    [SerializeField] private Image imgMusicP;
    [SerializeField] private Image imgSfxP;
    [SerializeField] private Sprite sprMusic0;
    [SerializeField] private Sprite sprMusic1;
    [SerializeField] private Sprite sprSfx0;
    [SerializeField] private Sprite sprSfx1;

    [SerializeField] private Transform Tutorial;
    [SerializeField] private Transform AudioMenu;

    [SerializeField] private GameObject BtnMusicPMenu;

    [SerializeField] private Button PlayButton;
    [SerializeField] private Slider SliderMusic;

    void OnEnable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.Select();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() {

        for( int i = 0; i < transform.childCount; ++i ){

            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        Follower.gameObject.SetActive(true);
        GameController.gameObject.SetActive(true);
        Hud.gameObject.SetActive(true);
        CameraMenu.gameObject.SetActive(false);
        CameraGame.gameObject.SetActive(true);
        //Stop música menú (...)

        StartCoroutine(StartGame());
    }

    public void Controls() {

        /*controlsTuto = !controlsTuto;
        ControlsTuto.gameObject.SetActive(controlsTuto);

        if (controlsTuto)
            StartCoroutine(CheckQuitControls());*/

        Tutorial.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void AudioSettings() {

        AudioMenu.gameObject.SetActive(true);
        SliderMusic.Select();
        gameObject.SetActive(false);
        BtnMusicPMenu.SetActive(false);
    }

    public void Quit() {

        Application.Quit();
    }

    public void MuteMusic() {

        muteMusic = !muteMusic;

        if (muteMusic) {

            imgMusic.sprite = sprMusic1;
            imgMusicP.sprite = sprMusic1;
            Audio.MuteMusic();
        }
        else {

            imgMusic.sprite = sprMusic0;
            imgMusicP.sprite = sprMusic0;
            Audio.DesMuteMusic();
        }
    }

    public void MuteSfx() {

        muteSfx = !muteSfx;

        if (muteSfx) {

            imgSfx.sprite = sprSfx1;
            imgSfxP.sprite = sprSfx1;
            Audio.MuteSfx();
        }
        else {

            imgSfx.sprite = sprSfx0;
            imgSfxP.sprite = sprSfx0;
            Audio.DesMuteSfx();
        }
    }

    IEnumerator StartGame() {

        yield return new WaitForSeconds(2.5f);
        Timer.Stop = false;
        Audio.Play("sfx_engine");
        Car.StartGame();
        
        this.gameObject.SetActive(false);
        //Play música juego (...)
        
    }
}
