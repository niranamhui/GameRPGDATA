using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swatc : MonoBehaviour
{
    public Terrain terrain;
    private int terrainWidth;
    private int terrainLength;
    private int terrainPosX;
    private int terrainPosZ;

    public GameObject nagent;
   
   
    void Start()
    {
        terrainWidth = (int)terrain.terrainData.size.x;
        terrainLength = (int)terrain.terrainData.size.z;
        terrainPosX = (int)terrain.transform.position.x;
        terrainPosZ = (int)terrain.transform.position.z;

        Invoke("Spawnt", Random.Range(2, 5));
    }

    void Spawnt()
    {
        int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
        int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
        float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));

        GameObject na = (GameObject)Instantiate(nagent, new Vector3(posx, posy, posz), Quaternion.identity);
        

        Invoke("Spawnt", Random.Range(2, 5));
    }

}
