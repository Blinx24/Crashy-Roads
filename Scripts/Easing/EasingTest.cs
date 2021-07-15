using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
[ExecuteInEditMode]
public class EasingTest : MonoBehaviour
{
    [SerializeField] GameObject testingObject;
    [SerializeField] float start;
    [SerializeField] float dest;
    [SerializeField] EasingFunctions.Easing easingType;
    [SerializeField] TypeTest typeTest;
    private EasingFunctions ez;
    private float t = 0f;
    private bool go = false;
    private bool enableEasing;
    private bool inverse = false;

    public enum TypeTest {

        TranslateX = 0,
        TranslateY,
        TranslateZ,
        Size,
        SizeX,
        SizeY,
        SizeZ,
    }

    public bool EnableEasing {
        get{
            return enableEasing;
        }
        set{
            enableEasing = value;
        }
    }

    public bool Go {
        get{
            return go;
        }
        set{
            go = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ez = GetComponent<EasingFunctions>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.zero;

        if (enableEasing) {

            go = true;
            enableEasing = false;
        }

        if (go) {

            float value = ez.DoEasing(easingType, start, dest, t);

            switch (typeTest) {

                case TypeTest.TranslateX:
                    testingObject.transform.position = new Vector3(value, testingObject.transform.position.y, testingObject.transform.position.z);
                break;
                case TypeTest.TranslateY:
                    testingObject.transform.position = new Vector3(testingObject.transform.position.x, value, testingObject.transform.position.z);
                break;
                case TypeTest.TranslateZ:
                    testingObject.transform.position = new Vector3(testingObject.transform.position.x, testingObject.transform.position.y, value);
                break;
                case TypeTest.Size:
                    testingObject.transform.localScale = new Vector3(value, value, value);
                break;
                case TypeTest.SizeX:
                    testingObject.transform.localScale = new Vector3(value, testingObject.transform.localScale.y, testingObject.transform.localScale.z);
                break;
                case TypeTest.SizeY:
                    testingObject.transform.localScale = new Vector3(testingObject.transform.localScale.x, value, testingObject.transform.localScale.z);
                break;
                case TypeTest.SizeZ:
                    testingObject.transform.localScale = new Vector3(testingObject.transform.localScale.x, testingObject.transform.localScale.y, value);
                break;

            }

            if (!inverse)
                t = Mathf.Min(t + Time.deltaTime, 1);
            else
                t = Mathf.Max(0, t - Time.deltaTime);
        }

        if ((t == 1 && !inverse) || (t == 0 && inverse)) {

            //StartCoroutine("waitToFinish");
            go = false;
            inverse = !inverse;
            enableEasing = false;
        }

    }
    
    void OnDrawGizmos() {

        UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
        UnityEditor.SceneView.RepaintAll();
    }

    IEnumerator waitToFinish() {

        yield return new WaitForSeconds(0.5f);
        go = false;
        inverse = !inverse;
        enableEasing = false;

        /*switch (typeTest) {

            case TypeTest.TranslateX:
                testingObject.transform.position = new Vector3(start, testingObject.transform.position.y, testingObject.transform.position.z);
            break;
            case TypeTest.TranslateY:
                testingObject.transform.position = new Vector3(testingObject.transform.position.x, start, testingObject.transform.position.z);
            break;
            case TypeTest.TranslateZ:
                testingObject.transform.position = new Vector3(testingObject.transform.position.x, testingObject.transform.position.y, start);
            break;
            case TypeTest.Size:
                testingObject.transform.localScale = new Vector3(start, start, start);
            break;
            case TypeTest.SizeX:
                testingObject.transform.localScale = new Vector3(start, testingObject.transform.localScale.y, testingObject.transform.localScale.z);
            break;
            case TypeTest.SizeY:
                testingObject.transform.localScale = new Vector3(testingObject.transform.localScale.x, start, testingObject.transform.localScale.z);
            break;
            case TypeTest.SizeZ:
                testingObject.transform.localScale = new Vector3(testingObject.transform.localScale.x, testingObject.transform.localScale.y, start);
            break;

        }*/
    }

    public void ResetValues() {

        switch (typeTest) {

            case TypeTest.TranslateX:
            start = testingObject.transform.position.x;
            break;
            case TypeTest.TranslateY:
            start = testingObject.transform.position.y;
            break;
            case TypeTest.TranslateZ:
            start = testingObject.transform.position.z;
            break;
            case TypeTest.Size:
            start = testingObject.transform.localScale.x;
            break;
            case TypeTest.SizeX:
            start = testingObject.transform.localScale.x;
            break;
            case TypeTest.SizeY:
            start = testingObject.transform.localScale.y;
            break;
            case TypeTest.SizeZ:
            start = testingObject.transform.localScale.z;
            break;
        }
    }
}
#endif