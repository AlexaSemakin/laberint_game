using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ManagerGameLab;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    List<GameObject> sides = new List<GameObject>();
    [SerializeField] GameObject Back;
    [SerializeField] GameObject Right;
    [SerializeField] GameObject Front;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Top;
    [SerializeField] GameObject Bottom;

    [SerializeField] GameObject distanceText;
    [SerializeField] GameObject CoordsText;
    [SerializeField] GameObject boolVector;




    public Material[] visible;
    public Material inVisible;

    
    void Start()
    {
        CoordsText.GetComponent<TextMesh>().text = $"{(int)gameObject.transform.position.x/10}, {(int)gameObject.transform.position.y/10}, {(int)gameObject.transform.position.z/10}";
        distanceText.GetComponent<TextMesh>().text = $"{ManagerGame.getLengthToStart((int)gameObject.transform.position.x/10, (int)gameObject.transform.position.y/10, (int)gameObject.transform.position.z/10)}";
        boolVector.GetComponent<TextMesh>().text = $"{ManagerGame.getElement((int)gameObject.transform.position.x/10, (int)gameObject.transform.position.y/10, (int)gameObject.transform.position.z/10)}";

        sides.Add(Back);
        sides.Add(Right);
        sides.Add(Front);
        sides.Add(Left);
        sides.Add(Top);
        sides.Add(Bottom);
        Transparent(ManagerGame.getElement((int)gameObject.transform.position.x/10, (int)gameObject.transform.position.y/10, (int)gameObject.transform.position.z/10));
        
    }


    void Update()
    {
        
    }

 

    public void Transparent(DotElement dotElement){

        if(dotElement.getBack()){
            Back.GetComponent<MeshRenderer>().material = visible[0];
        }
        else{
            Back.GetComponent<MeshRenderer>().material = inVisible;
        }

        if(dotElement.getRight()){
            Right.GetComponent<MeshRenderer>().material = visible[1];
        }
        else{
            Right.GetComponent<MeshRenderer>().material = inVisible;
        }

        if(dotElement.getFront()){
            Front.GetComponent<MeshRenderer>().material = visible[2];
        }
        else{
            Front.GetComponent<MeshRenderer>().material = inVisible;
        }
        
        if(dotElement.getLeft()){
            Left.GetComponent<MeshRenderer>().material = visible[3];
        }
        else{
            Left.GetComponent<MeshRenderer>().material = inVisible;
        }

        if(dotElement.getTop()){
            Top.GetComponent<MeshRenderer>().material = visible[4];
        }
        else{
            Top.GetComponent<MeshRenderer>().material = inVisible;
        }

        if(dotElement.getBottom()){
            Bottom.GetComponent<MeshRenderer>().material = visible[5];
        }
        else{
            Bottom.GetComponent<MeshRenderer>().material = inVisible;
        }
    }
}
