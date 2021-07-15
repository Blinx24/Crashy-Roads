using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioClip mus_game, mus_win, mus_defeat;
    public static AudioClip sfx_engine, sfx_drift, sfx_correct, sfx_grabFuel;
    [SerializeField] private AudioSource[] musicSource;
    [SerializeField] private AudioSource[] sfxSource; 

    [SerializeField] private float maxVolMusic;
    [SerializeField] private float maxVolSfx;

    public AudioSource[] MusicSource
    {
        get {return musicSource; }
        set {musicSource = value; }
    }
    public AudioSource[] SfxSource
    {
        get {return sfxSource; }
        set {sfxSource = value; }
    }

    //Scene currentScene;
    //string sceneName;

    [SerializeField] private bool muteMusic; 

    void Start(){
        
        sfx_engine = Resources.Load<AudioClip>("sfx_engine");
        sfx_drift = Resources.Load<AudioClip>("sfx_drift");
        sfx_correct = Resources.Load<AudioClip>("sfx_correct");
        sfx_grabFuel = Resources.Load<AudioClip>("sfx_grabFuel");

        mus_game = Resources.Load<AudioClip>("mus_game");
        mus_win = Resources.Load<AudioClip>("mus_win");
        mus_defeat = Resources.Load<AudioClip>("mus_defeat");

        //Play música menu(...)
        Play("mus_game");

        DontDestroyOnLoad(this.gameObject);
        //if (sceneName == "Escena")
            //PlayCantina();

        //if (muteMusic) musicSource[0].volume = 0f;
    }

    public void PauseAll() {
        
        for (int i = 0; i < musicSource.Length; i++) {

            musicSource[i].Pause();
        }
        for (int i = 0; i < sfxSource.Length; i++) {

            sfxSource[i].Pause();
        }
    }
    public void ResumeAll() {
        
        for (int i = 0; i < musicSource.Length; i++) {

            musicSource[i].UnPause();
        }
        for (int i = 0; i < sfxSource.Length; i++) {

            sfxSource[i].UnPause();
        }
    }
    public void StopAll() {
        
        for (int i = 0; i < musicSource.Length; i++) {

            musicSource[i].Stop();
        }
        for (int i = 0; i < sfxSource.Length; i++) {

            sfxSource[i].Stop();
        }
    }
    public void StopMusic() {
        
        for (int i = 0; i < musicSource.Length; i++) {

            musicSource[i].Stop();
        }
    }
    public void StopSfx() {

        for (int i = 0; i < sfxSource.Length; i++) {

            sfxSource[i].Stop();
        }
    }
    public void MuteMusic() {
        
        for (int i = 0; i < musicSource.Length; i++) {

            musicSource[i].volume = 0;
        }
    }
    public void MuteSfx() {

        for (int i = 0; i < sfxSource.Length; i++) {

            sfxSource[i].volume = 0;
        }
    }
    public void DesMuteMusic() {
        
        for (int i = 0; i < musicSource.Length; i++) {

            musicSource[i].volume = 0.07f;
        }
    }
    public void DesMuteSfx() {

        for (int i = 0; i < sfxSource.Length; i++) {

            sfxSource[i].volume = 0.02f;
        }
    }

    public void SetMusic(float n) {
        for (int i = 0; i < musicSource.Length; i++) {

            musicSource[i].volume = Mathf.Lerp(0, maxVolMusic, n/1f);
        }
    }
    public void SetSfx(float n) {
        for (int i = 0; i < sfxSource.Length; i++) {

            sfxSource[i].volume = Mathf.Lerp(0, maxVolSfx, n/1f);
        }
    }

    /*
    public void Resume() {
        
        musicSource.UnPause();
        sfxSource.UnPause();
        sfxSource2.UnPause();
        sfxSource3.UnPause();
    }

    public void PlayCantina(){
        //source.PlayOneShot(binvenida);
        musicSource.clip = mus_cantina;
        musicSource.loop = true;
        musicSource.Play(); 
    }

    public IEnumerator PlayBattle(){
        musicSource.Stop(); 
        //musicSource.PlayOneShot(mus_batalla1);
        musicSource.clip = mus_batalla1;
        musicSource.loop = false;
        musicSource.Play(); 

        yield return new WaitUntil(() => (!musicSource.isPlaying && musicSource.clip == mus_batalla1));
        
        musicSource.clip = mus_batalla2;
        musicSource.loop = true;
        musicSource.Play(); 
    }

    public IEnumerator PlaySwipe(){
        
        //musicSource.PlayOneShot(mus_batalla1);
        sfxSource3.clip = sfx_swipe;
        sfxSource3.loop = false;
        sfxSource3.Play(); 

        yield return new WaitUntil(() => (!sfxSource3.isPlaying && sfxSource3.clip == sfx_swipe));
        
        sfxSource3.clip = null;
        sfxSource3.loop = false;
        sfxSource3.Stop(); 
    }*/

    public void Play(string n)
    {
        
        switch(n)
        {
            case "sfx_engine":
                sfxSource[0].clip = sfx_engine;
                sfxSource[0].loop = true;
                if (sfxSource[1].volume != 0)
                    sfxSource[1].volume = 0.3f;
                sfxSource[0].Play();
            break;
            case "sfx_grabFuel":
                sfxSource[1].clip = sfx_grabFuel;
                sfxSource[1].loop = false;
                sfxSource[1].Play();
            break;
            case "sfx_drift":
                sfxSource[1].clip = sfx_drift;
                if (sfxSource[1].volume != 0)
                    sfxSource[1].volume = 0.1f;
                sfxSource[1].loop = false;
                sfxSource[1].Play();
            break;
            case "sfx_correct":
                sfxSource[1].clip = sfx_correct;
                if (sfxSource[1].volume != 0)
                    sfxSource[1].volume = 0.8f;
                sfxSource[1].loop = false;
                sfxSource[1].Play();
            break;
            case "mus_game":
                musicSource[0].Stop();
                musicSource[0].clip = mus_game;
                musicSource[0].loop = true;
                if (musicSource[0].volume != 0)
                    musicSource[0].volume = 0.05f;
                musicSource[0].Play();
            break;
            case "mus_win":
                musicSource[0].Stop();
                musicSource[0].clip = mus_win;
                musicSource[0].loop = false;
                if (musicSource[0].volume != 0)
                    musicSource[0].volume = 0.16f;
                musicSource[0].Play();
            break;
            case "mus_defeat":
                musicSource[0].Stop();
                musicSource[0].clip = mus_defeat;
                musicSource[0].loop = false;
                if (musicSource[0].volume != 0)
                    musicSource[0].volume = 0.1f;
                musicSource[0].Play();
            break;
        }
    }

}
