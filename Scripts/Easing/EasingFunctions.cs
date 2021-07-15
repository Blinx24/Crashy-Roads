using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingFunctions : MonoBehaviour
{
    private float valueInTime = 0f;
    private float time = 0f;
    private float speed = 0f;

    public float ValueInTime{
        get{
            return valueInTime;
        }
        set{
            valueInTime=value;
        }
    }

    public enum Easing {
        
        easeInSine = 0,
        easeOutSine,
        easeInOutSine,

        easeInCubic,
        easeOutCubic,
        easeInOutCubic,

        easeInQuint,
        easeOutQuint,
        easeInOutQuint,

        easeInCirc,
        easeOutCirc,
        easeInOutCirc,

        easeInElastic,
        easeOutElastic,
        easeInOutElastic,

        easeInQuad,
        easeOutQuad,
        easeInOutQuad,

        easeInQuart,
        easeOutQuart,
        easeInOutQuart,

        easeInExpo,
        easeOutExpo,
        easeInOutExpo,

        easeInBack,
        easeOutBack,
        easeInOutBack,

        easeInBounce,
        easeOutBounce,
        easeInOutBounce,
    }

    public float DoEasing (Easing e, float start, float dest, float t) {

        float value = 0;
        switch(e) {
            
            case Easing.easeInSine:
                value = EaseInSine(start, dest, t);
            break;
            case Easing.easeOutSine:
                value = EaseOutSine(start, dest, t);
            break;
            case Easing.easeInOutSine:
                value = EaseInOutSine(start, dest, t);
            break;
            case Easing.easeInCubic:
                value = EaseInCubic(start, dest, t);
            break;
            case Easing.easeOutCubic:
                value = EaseOutCubic(start, dest, t);
            break;
            case Easing.easeInOutCubic:
                value = EaseInOutCubic(start, dest, t);
            break;
            case Easing.easeInQuint:
                value = EaseInQuint(start, dest, t);
            break;
            case Easing.easeOutQuint:
                value = EaseOutQuint(start, dest, t);
            break;
            case Easing.easeInOutQuint:
                value = EaseInOutQuint(start, dest, t);
            break;
            case Easing.easeInCirc:
                value = EaseInCirc(start, dest, t);
            break;
            case Easing.easeOutCirc:
                value = EaseOutCirc(start, dest, t);
            break;
            case Easing.easeInOutCirc:
                value = EaseInOutCirc(start, dest, t);
            break;
            case Easing.easeInElastic:
                value = EaseInElastic(start, dest, t);
            break;
            case Easing.easeOutElastic:
                value = EaseOutElastic(start, dest, t);
            break;
            case Easing.easeInOutElastic:
                value = EaseInOutElastic(start, dest, t);
            break;
            case Easing.easeInQuad:
                value = EaseInQuad(start, dest, t);
            break;
            case Easing.easeOutQuad:
                value = EaseOutQuad(start, dest, t);
            break;
            case Easing.easeInOutQuad:
                value = EaseInOutQuad(start, dest, t);
            break;
            case Easing.easeInQuart:
                value = EaseInQuart(start, dest, t);
            break;
            case Easing.easeOutQuart:
                value = EaseOutQuart(start, dest, t);
            break;
            case Easing.easeInOutQuart:
                value = EaseInOutQuart(start, dest, t);
            break;
            case Easing.easeInExpo:
                value = EaseInExpo(start, dest, t);
            break;
            case Easing.easeOutExpo:
                value = EaseOutExpo(start, dest, t);
            break;
            case Easing.easeInOutExpo:
                value = EaseInOutExpo(start, dest, t);
            break;
            case Easing.easeInBack:
                value = EaseInBack(start, dest, t);
            break;
            case Easing.easeOutBack:
                value = EaseOutBack(start, dest, t);
            break;
            case Easing.easeInOutBack:
                value = EaseInOutBack(start, dest, t);
            break;
            case Easing.easeInBounce:
                value = EaseInBounce(start, dest, t);
            break;
            case Easing.easeOutBounce:
                value = EaseOutBounce(start, dest, t);
            break;
            case Easing.easeInOutBounce:
                value = EaseInOutBounce(start, dest, t);
            break;
        }

        return value;
    }

    public IEnumerator DoEasingCoroutine (Easing e, float start, float dest, float duration) {
        
        bool finish = false;
        while (!finish) {
            speed = duration * Time.unscaledDeltaTime;

            switch(e) {

                case Easing.easeInSine:
                    valueInTime = EaseInSine(start, dest, time);
                break;
                case Easing.easeOutSine:
                    valueInTime = EaseOutSine(start, dest, time);
                break;
                case Easing.easeInOutSine:
                    valueInTime = EaseInOutSine(start, dest, time);
                break;
                case Easing.easeInCubic:
                    valueInTime = EaseInCubic(start, dest, time);
                break;
                case Easing.easeOutCubic:
                    valueInTime = EaseOutCubic(start, dest, time);
                break;
                case Easing.easeInOutCubic:
                    valueInTime = EaseInOutCubic(start, dest, time);
                break;
                case Easing.easeInQuint:
                    valueInTime = EaseInQuint(start, dest, time);
                break;
                case Easing.easeOutQuint:
                    valueInTime = EaseOutQuint(start, dest, time);
                break;
                case Easing.easeInOutQuint:
                    valueInTime = EaseInOutQuint(start, dest, time);
                break;
                case Easing.easeInCirc:
                    valueInTime = EaseInCirc(start, dest, time);
                break;
                case Easing.easeOutCirc:
                    valueInTime = EaseOutCirc(start, dest, time);
                break;
                case Easing.easeInOutCirc:
                    valueInTime = EaseInOutCirc(start, dest, time);
                break;
                case Easing.easeInElastic:
                    valueInTime = EaseInElastic(start, dest, time);
                break;
                case Easing.easeOutElastic:
                    valueInTime = EaseOutElastic(start, dest, time);
                break;
                case Easing.easeInOutElastic:
                    valueInTime = EaseInOutElastic(start, dest, time);
                break;
                case Easing.easeInQuad:
                    valueInTime = EaseInQuad(start, dest, time);
                break;
                case Easing.easeOutQuad:
                    valueInTime = EaseOutQuad(start, dest, time);
                break;
                case Easing.easeInOutQuad:
                    valueInTime = EaseInOutQuad(start, dest, time);
                break;
                case Easing.easeInQuart:
                    valueInTime = EaseInQuart(start, dest, time);
                break;
                case Easing.easeOutQuart:
                    valueInTime = EaseOutQuart(start, dest, time);
                break;
                case Easing.easeInOutQuart:
                    valueInTime = EaseInOutQuart(start, dest, time);
                break;
                case Easing.easeInExpo:
                    valueInTime = EaseInExpo(start, dest, time);
                break;
                case Easing.easeOutExpo:
                    valueInTime = EaseOutExpo(start, dest, time);
                break;
                case Easing.easeInOutExpo:
                    valueInTime = EaseInOutExpo(start, dest, time);
                break;
                case Easing.easeInBack:
                    valueInTime = EaseInBack(start, dest, time);
                break;
                case Easing.easeOutBack:
                    valueInTime = EaseOutBack(start, dest, time);
                break;
                case Easing.easeInOutBack:
                    valueInTime = EaseInOutBack(start, dest, time);
                break;
                case Easing.easeInBounce:
                    valueInTime = EaseInBounce(start, dest, time);
                break;
                case Easing.easeOutBounce:
                    valueInTime = EaseOutBounce(start, dest, time);
                break;
                case Easing.easeInOutBounce:
                    valueInTime = EaseInOutBounce(start, dest, time);
                break;
            }

            time = Mathf.Min(time + speed, 1f);
            
            if (time == 1)
                finish = true;

            yield return new WaitForEndOfFrame();
            if (finish) {

                time = 0;
                valueInTime = 0;
            }
            
        }
        
    }


    //EASING FUNCTIONS//

    // https://easings.net/#easeInSine
    private float EaseInSine(float start, float dest, float t){
        float value;

        value = 1 - Mathf.Cos((t * Mathf.PI) / 2);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutSine
    private float EaseOutSine(float start, float dest, float t){
        float value;

        value = Mathf.Sin((t * Mathf.PI) / 2);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutSine
    private float EaseInOutSine(float start, float dest, float t){
        float value;

        value = -(Mathf.Cos(Mathf.PI * t) - 1) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInCubic
    private float EaseInCubic(float start, float dest, float t){
        float value;

        value = t * t * t;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutCubic
    private float EaseOutCubic(float start, float dest, float t){
        float value;

        value = 1 - Mathf.Pow(1 - t, 3);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutCubic
    private float EaseInOutCubic(float start, float dest, float t){
        float value;

        if (t < .5f)
            value = 4 * t * t * t;
        else
            value = 1 - Mathf.Pow(-2 * t + 2, 3) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInQuint
    private float EaseInQuint(float start, float dest, float t){
        float value;

        value = t * t * t * t * t;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutQuint
    private float EaseOutQuint(float start, float dest, float t){
        float value;

        value = 1 - Mathf.Pow(1 - t, 5);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutQuint
    private float EaseInOutQuint(float start, float dest, float t){
        float value;

        if (t < 0.5)
            value = 16 * t * t * t * t * t;
        else
            value = 1 - Mathf.Pow(-2 * t + 2, 5) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInCirc
    private float EaseInCirc(float start, float dest, float t){

        float value;
        
        value = 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutCirc
    private float EaseOutCirc(float start, float dest, float t){

        float value;
        
        value = Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutCirc
    private float EaseInOutCirc(float start, float dest, float t){

        float value;
        if (t < 0.5)
            value = (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2;
        else
            value = (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInElastic
    private float EaseInElastic(float start, float dest, float t){

        float value;
        const float c4 = (2 * Mathf.PI) / 3;

        if (t == 0)
            value = 0f;
        else if (t == 1)
            value = 1f;
        else
            value = -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10f - 10.75f) * c4);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutElastic
    private float EaseOutElastic(float start, float dest, float t){

        float value;
        
        const float c4 = (2 * Mathf.PI) / 3;
        if (t == 0)
            value = 0f;
        else if (t == 1)
            value = 1f;
        else
            value = Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10f - 0.75f) * c4) + 1;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutElastic
    private float EaseInOutElastic(float start, float dest, float t){

        float value;
        const float c5 = (2 * Mathf.PI) / 4.5f;

        if (t == 0)
            value = 0f;
        else if (t == 1)
            value = 1f;
        else if (t < 0.5)
            value = -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2;
        else
            value = (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2 + 1;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInQuad
    private float EaseInQuad(float start, float dest, float t){

        float value;
        
        value = t * t;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutQuad
    private float EaseOutQuad(float start, float dest, float t){

        float value;
        
        value = 1 - (1 - t) * (1 - t);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutQuad
    private float EaseInOutQuad(float start, float dest, float t){

        float value;
        
        if (t < 0.5)
            value = 2 * t * t;
        else
            value = 1 - Mathf.Pow(-2 * t + 2, 2) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInQuart
    private float EaseInQuart(float start, float dest, float t){

        float value;
        value = t * t * t * t;
        return (dest-start)*value+start;
    }


    // https://easings.net/#easeOutQuart
    private float EaseOutQuart(float start, float dest, float t){

        float value;
        value = 1 - Mathf.Pow(1 - t, 4);
        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutQuart
    private float EaseInOutQuart(float start, float dest, float t){

        float value;
        
        if (t < 0.5)
            value = 8 * t * t * t * t;
        else
            value = 1 - Mathf.Pow(-2 * t + 2, 4) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInExpo
    private float EaseInExpo(float start, float dest, float t){

        float value;

        if (t == 0)
            value = 0f;
        else
            value = Mathf.Pow(2, 10 * t - 10);
        
        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutExpo
    private float EaseOutExpo(float start, float dest, float t){

        float value;

        if (t == 1)
            value = 1f;
        else
            value = 1 - Mathf.Pow(2, -10 * t);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutExpo
    private float EaseInOutExpo(float start, float dest, float t){

        float value;

        if (t == 0)
            value = 0f;
        else if (t == 1)
            value = 1f;
        else if (t < 0.5)
            value = Mathf.Pow(2, 20 * t - 10) / 2;
        else
            value = (2 - Mathf.Pow(2, -20 * t + 10)) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInBack
    private float EaseInBack(float start, float dest, float t){
        
        float value;   
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        value = c3 * t * t * t - c1 * t * t;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutBack
    private float EaseOutBack(float start, float dest, float t){
        
        float value;
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        value = 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutBack
    private float EaseInOutBack(float start, float dest, float t){
        
        float value;   
        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;

        if (t < 0.5)
            value = (Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2;
        else
            value = (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInBounce
    private float EaseInBounce(float start, float dest, float t){
        
        float value;   
        value = 1 - EaseOutBounce(0, 1, 1 - t);
        return (dest-start)*value+start;
    }

    // https://easings.net/#easeOutBounce
    private float EaseOutBounce(float start, float dest, double t){

        float value;
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (t < 1 / d1) {

            value = (float)(n1 * t * t);

        } else if (t < 2 / d1) {

            value = (float)(n1 * (t -= 1.5 / d1) * t + 0.75);

        } else if (t < 2.5 / d1) {

            value = (float)(n1 * (t -= 2.25 / d1) * t + 0.9375);

        } else {

            value = (float)(n1 * (t -= 2.625 / d1) * t + 0.984375);
        }

        return (dest-start)*value+start;
    }

    // https://easings.net/#easeInOutBounce
    private float EaseInOutBounce(float start, float dest, float t){
        
        float value;
        if (t < 0.5)
            value = (1 - EaseOutBounce(0, 1, 1 - 2 * t)) / 2;
        else
            value = (1 + EaseOutBounce(0, 1, 2 * t - 1)) / 2;

        return (dest-start)*value+start;
    }
}
