using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawn : MonoBehaviour
{
    public int ObjectAmount;
    public GameObject spawnable;

    void Start()
    {
       
        for (int i = 0; i < ObjectAmount; i++)
        {
            this.transform.position += new Vector3(Random.Range(-7, 7),0,Random.Range(-7, 7));
            Ray raycros = new Ray(this.transform.position, -this.transform.up);
            if(Physics.Raycast(raycros,out RaycastHit hit, 20)){
                if(hit.collider.tag == "terrain"){
                    GameObject temp = Instantiate(spawnable, hit.point, Quaternion.identity);
                    temp.transform.Rotate(0, Random.Range(0, 360), 0);
                    temp.transform.parent = this.transform.parent;                    
                }
            }
        }    
    }
}
