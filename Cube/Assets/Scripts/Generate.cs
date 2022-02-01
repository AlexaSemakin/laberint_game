using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ManagerGameLab;
public class Generate : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
     //Cube cube;
   
    void Start()
    {
        //cube = GameObject.FindObjectOfType<Cube>(); 
        GameObject cubeClone;
        Point size = new Point(4, 4, 4);
        Point current = new Point(0);
        ManagerGame.GenerateMap(new SizeMap(size));
        print(size.X);
        
        for (int i=0; i < size.X; i++)
        {
            current.X = i * 10;
            for (int j = 0; j < size.Y; j++)
            {
                current.Y = j * 10;
                for (int k = 0; k < size.Z; k++)
                {
                    current.Z = k * 10;
                    cubeClone = Instantiate(cubePrefab, new Vector3((float)current.X, (float)current.Y, (float)current.Z), Quaternion.identity);
                }
            }
        }
    }

    
    void Update()
    {
        
    }
    
}
