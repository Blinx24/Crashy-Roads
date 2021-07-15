using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] [Range(1,6)] public int gearLevel;
    private TextMeshPro txtGear;

    private Transform cam;

    //Getters y setters

    public int GearLevel
    {
        get {return gearLevel; }
        set {gearLevel = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        txtGear = GetComponentInChildren<TextMeshPro>();
        txtGear.text = gearLevel.ToString();

        cam = GameObject.Find("Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TxtTransform);
        txtGear.transform.rotation = cam.rotation;
    }
}
