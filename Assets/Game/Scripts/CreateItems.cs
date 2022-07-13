using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItems : MonoBehaviour
{
    [SerializeField]
    private  List<GameObject> listItems = new List<GameObject>();
    [SerializeField]
    private GameObject zone;
    public int numberItems = 30;
    public float zShift = -2.81f;
    public float xShift = 0.00f; 

    void Awake()
    {
        var breadthZone = zone.GetComponent<BoxCollider>().size.z / 4;
        var widthZone = zone.GetComponent<BoxCollider>().size.x / 4;

        for (var i = 0; i < numberItems; i++)
        {
            var item = listItems[Random.Range(0, listItems.Count)];
            Vector3 position = new Vector3(Random.Range(-widthZone + xShift, widthZone + xShift), 0, 
                Random.Range(-breadthZone + zShift, breadthZone + zShift));
            Instantiate(item, position, transform.rotation);
            Debug.Log(position);
        }
    }
}
