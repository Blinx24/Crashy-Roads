using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SoundSettingsController : MonoBehaviour
{
    [SerializeField] private Transform Menu;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Transform PauseMenu;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private GameObject GameController;
    [SerializeField] private GameObject BtnMusicPMenu;

    [SerializeField] private Slider SliderMusic;
    [SerializeField] private Slider SliderSfx;

    [SerializeField] private Color ColorHighlight;
    [SerializeField] private Color ColorNormal;

    [SerializeField] private TMP_Text MusicText;
    [SerializeField] private TMP_Text SfxText;

    [SerializeField] private AudioManager AudioManager;
    

    private float PrevMusicValue = 1;
    private float PrevSfxValue = 1;
    
    void Start()
    {
        //ButtonMusic.Focus();
        //MusicText = SliderMusic.GetComponentInChildren<TMP_Text>();
        //MusicSfx = SliderSfx.GetComponentInChildren<TMP_Text>();

        //SliderMusic.Select();
        //HighlightMusic();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighlightMusic() {
        MusicText.color = ColorHighlight;
    }
    public void HighlightSfx() {
        SfxText.color = ColorHighlight;
    }
    public void UnHighlightMusic() {
        MusicText.color = ColorNormal;
    }
    public void UnHighlightSfx() {
        SfxText.color = ColorNormal;
    }
    public void MuteMusic() {
        if (SliderMusic.value == 0) {
            SliderMusic.value = PrevMusicValue;
        }
        else {
            PrevMusicValue = SliderMusic.value;
            SliderMusic.value = 0;
        }

        HighlightMusic();
    }
    public void MuteSfx() {
        if (SliderSfx.value == 0) {
            SliderSfx.value = PrevSfxValue;
        }
        else {
            PrevSfxValue = SliderSfx.value;
            SliderSfx.value = 0;
        }
        HighlightSfx();
    }

    public void GetSliderMusicVal() {
        AudioManager.SetMusic(SliderMusic.value);
    }
    public void GetSliderSfxVal() {
        AudioManager.SetSfx(SliderSfx.value);
    }

    public void ExitBtn() {

        StartCoroutine(Exit());
    }
    public IEnumerator Exit() {
        yield return new WaitForSecondsRealtime(0.15f);
        if (!GameController.activeSelf) {
            Menu.gameObject.SetActive(true);
            gameObject.SetActive(false);

            PlayButton.Select();
        }
        else {
            gameObject.SetActive(false);

            ResumeButton.Select();
        }
        BtnMusicPMenu.gameObject.SetActive(true);        
    }
}
