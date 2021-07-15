using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
public class GenerateModels : MonoBehaviour
{
    private int gearLevel;

    [SerializeField] public List<GameObject> ObsModels;
    [SerializeField] private Transform ModelPos;

    // Start is called before the first frame update
    void Start()
    {
        gearLevel = GetComponent<ObstacleController>().GearLevel;

        //Generar modelo correspondiente
        //GameObject Inst = Instantiate(ObsModels[gearLevel - 1], ModelPos.position, ModelPos.transform.rotation, transform);
        //Inst.transform.localScale = new Vector3(2.5f,2.5f,2.5f);

        /*MeshFilter ModelMesh = Inst.GetComponentInChildren<MeshFilter>();
        Transform ModelTransform = Inst.GetComponentInChildren<Transform>();
        txtGear.transform.localPosition = new Vector3(txtGear.transform.localPosition.x, ModelMesh.mesh.bounds.extents.y*2*100+0.48f, txtGear.transform.localPosition.z);*/

        switch(gearLevel) {

            case 1:
                
            break;
            case 2:
                //Inst.transform.localPosition = new Vector3(2, Inst.transform.localPosition.y, Inst.transform.localPosition.z);
            break;
            case 3:
                
            break;
            case 4:
                
            break;
            case 5:
                
            break;
            case 6:
                
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
#endif