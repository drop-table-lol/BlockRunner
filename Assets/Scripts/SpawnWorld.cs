using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWorld : MonoBehaviour
{

    //Arrays from which to grab random prefabs
    public GameObject[] floors;
    public Material[] floorMats;
    public GameObject[] powerups;

    //specific prefabs which we can manipulate at will
    public GameObject obstacle;
    GameObject clone; //and empty handle we use to adjust the latest spawned objects info.

    //Math stuff which we need to keep track of for spawning purposes
    Vector3 floorSpawnLocation = new Vector3(0, 0, 45);
    Vector3 objectSpawnLocation;
    Vector3 rando; //for spawning obstacles
    int groundsize = 200; //Hardcoded = bad. Int and var = good
    int objectCount = 18; //based on difficulty? also, still hardcoded


    void Start()
    {
        clone = Instantiate(floors[Random.Range(0, floors.Length)], floorSpawnLocation, Quaternion.identity);
        clone.GetComponent<Renderer>().material = floorMats[Random.Range(0, floorMats.Length)];
        floorSpawnLocation.z += groundsize;
        objectSpawnLocation = Vector3.zero;
        objectSpawnLocation.z += groundsize + 20;
        rando.y = 1;
    }


    public void SpawnFloor()
    {
        floorSpawnLocation.x += Random.Range(-5, 5);
        clone = Instantiate(floors[Random.Range(0, floors.Length)], floorSpawnLocation, Quaternion.identity);
        clone.GetComponent<Renderer>().material = floorMats[Random.Range(0, floorMats.Length)];
        floorSpawnLocation.z += groundsize;
        for (int i=0; i<objectCount/3; i++)
        {
            SpawnObjects();
            objectSpawnLocation.z += groundsize/6;
        }
        objectSpawnLocation.z = floorSpawnLocation.z - groundsize/2;
        objectSpawnLocation.x = floorSpawnLocation.x;
    }


    void SpawnObjects()
    {
        for (int i = 0; i < objectCount / 3; i++)
        {
            rando.x = Random.Range(-7, 7);
            rando.z = Random.Range(-5, 5);
            clone = Instantiate(obstacle, objectSpawnLocation + rando, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(Random.Range(-1000, 1000), Random.Range(0, 1500), 0);
        }

    }
}
