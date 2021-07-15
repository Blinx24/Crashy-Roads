using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GoalIndicator : MonoBehaviour
{
    [SerializeField] private Transform Follower;
    [SerializeField] private PathCreator PathCreator;
    private RectTransform Rect;
    private float progress;

    public float Progress
    {
        get {return progress; }
        set {progress = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        progress = PathCreator.path.GetClosestTimeOnPath(Follower.transform.position);

        Rect.localPosition = new Vector3(Mathf.Lerp(-249.5f, 249.5f, progress) , Rect.localPosition.y, Rect.localPosition.z);

        //Debug.Log(progress);
    }
}
