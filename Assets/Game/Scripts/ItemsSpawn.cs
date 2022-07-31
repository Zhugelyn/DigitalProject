using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    [SerializeField]
    private  List<GameObject> listItemTypes = new List<GameObject>();
    [SerializeField]
    private static List<GameObject> listItemPrefabs= new List<GameObject>();
    [SerializeField]
    private GameObject zone;
    [SerializeField]
    private int numberItems = 30;

    void Awake()
    {
        var breadthZone = zone.GetComponent<BoxCollider>().size.z / 2 * transform.localScale.z;
        var widthZone = zone.GetComponent<BoxCollider>().size.x / 2 * transform.localScale.x;
        var posX = transform.position.x;
        var posZ = transform.position.z;

        for (var i = 0; i < numberItems; i++)
        {
            var item = listItemTypes[Random.Range(0, listItemTypes.Count)];
            Vector3 position = new Vector3(Random.Range(-widthZone + posX, widthZone + posX), 0.5f, 
                Random.Range(-breadthZone + posZ, breadthZone + posZ));

            listItemPrefabs.Add(Instantiate(item, position, transform.rotation));
        }
    }

    public static void DestroyItems()
    {
        foreach (var item in listItemPrefabs)
            Destroy(item);
    }

}
