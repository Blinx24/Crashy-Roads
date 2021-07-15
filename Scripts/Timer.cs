using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private int timeWarn;
    [SerializeField] private Text txtTimerMinutes;
    [SerializeField] private Text txtTimerSeconds;
    [SerializeField] private Text txtTimerMili;

    [SerializeField] private Color NormalColor;
    [SerializeField] private Color WarnColor;

    private float time;
    private bool stop = true;
    private float tWarn = 0;
    private int warnsign = 1;

    //Getters y setters
    public bool Stop
    {
        get {return stop; }
        set {stop = value; }
    }

    public float Timertime
    {
        get {return time; }
        set {time = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        time = startTime;
        takeTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop) {

            time = Mathf.Max(0, time - Time.deltaTime);
            takeTime();

            if (time < timeWarn) {

                WarnTime();
            }
        }
        else {

            stop = true;
        }
    }

    private void takeTime() {

        int timeMinutes = (int)time/60;
        int timeSeconds = (int)time%60;
        int timeMili = (int)(time * 1000f) % 1000;

        if (timeMinutes >= 10) {
            txtTimerMinutes.text = timeMinutes.ToString()+":";
        }
        else {
            txtTimerMinutes.text = "0"+timeMinutes.ToString()+":";
        }
        if (timeSeconds >= 10) {
            txtTimerSeconds.text = timeSeconds.ToString()+":";
        }
        else {
            txtTimerSeconds.text = "0"+timeSeconds.ToString()+":";
        }
        if (timeMili >= 100) {
            txtTimerMili.text = timeMili.ToString();
        }
        else if ((timeMili >= 10)){
            txtTimerMili.text = "0"+timeMili.ToString();
        }
        else {
            txtTimerMili.text = "00"+timeMili.ToString();
        }
    }

    private void WarnTime() {

        if (tWarn == 1) {
            warnsign = -1;
        }
        else if (tWarn == 0){
            warnsign = 1;
        }
        
        tWarn = Mathf.Clamp(tWarn+Time.deltaTime*warnsign*0.7f, 0, 1);

        txtTimerMinutes.color = Color.Lerp(NormalColor, WarnColor, tWarn);
        txtTimerSeconds.color = Color.Lerp(NormalColor, WarnColor, tWarn);
        txtTimerMili.color = Color.Lerp(NormalColor, WarnColor, tWarn);

    }


}
