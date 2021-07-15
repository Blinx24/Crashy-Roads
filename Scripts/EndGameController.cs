using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private Text textEndGame;
    [SerializeField] private Text textScoreEnd;
    [SerializeField] private Text textEnd2;
    [SerializeField] private AudioManager Audio;

    //Getters y setters
    public Text TextEndGame
    {
        get {return textEndGame; }
        set {textEndGame = value; }
    }

    public Text TextEnd2
    {
        get {return textEnd2; }
        set {textEnd2 = value; }
    }

    public Text TextScoreEnd
    {
        get {return textScoreEnd; }
        set {textScoreEnd = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnMenu() {

        Destroy(Audio.gameObject);
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");//SceneManager.GetActiveScene().buildIndex
    }
}
