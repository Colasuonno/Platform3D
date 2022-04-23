using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public static List<GameObject> platforms = new List<GameObject>();

    private GameObject newTile = null;
    public GameObject prefab;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Everytime there is a collision on this block for the first team, generate another block

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (newTile == null)
        {
            // instantiate it
            // identity means no rotation
            newTile = Instantiate(prefab, GetNextPosition(), Quaternion.identity);
            platforms.Add(newTile);
        }
    }

    private Vector3 GetNextPosition()
    {

        float x = Random.Range(-3, 3);
        float y = Random.Range(0, 3);
        float z = Random.Range(5, 8);



        return new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
    }

    public static void clearPlatforms()
    {
        foreach (GameObject platform in platforms)
        {
            Destroy(platform);
        }
        platforms.Clear();
    }

}
