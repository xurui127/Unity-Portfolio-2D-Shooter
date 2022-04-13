using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField] GameObject prefab;
    [SerializeField] int size = 1;
    private Queue<GameObject> queue;
    private Transform parent;
    public GameObject Prefab => prefab;
    public int Size =>size;
    public int RunTimeSize => queue.Count;

   
 
    // Create Queue instance 
    public void Init(Transform parent)
    {
        queue = new Queue<GameObject>();
        this.parent = parent;
        // Enqueue all prefab instance in Queue
        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }
    // Create prefab instance 
    private GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab,parent);
        // when prefab created, disable prefab in inspector
        copy.SetActive(false);
        return copy; 
    }
    // Dequeue Availble Object in Queue(pool)
    private GameObject AvailableObject()
    {
        GameObject availableObject = null;
        //check queue size , and first object in queue is not active
        if (queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            // if all prefab is active in inspector, then create a copy prefab
            availableObject = Copy();
        }
        queue.Enqueue(availableObject);
        return availableObject;
    }

   // Set GameObject in queue 
    public GameObject PreparedObject()
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);

        return preparedObject;
    }
    /// <summary>
    /// override PreparedObject, and set PreparedObject position
    /// </summary>
    /// <param name="position"> set release position</param>
    /// <returns></returns>
    public GameObject PreparedObject(Vector3 position)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;

        return preparedObject;
    }
    /// <summary>
    /// override PreparedObject, and set PreparedObject position, rotation
    /// </summary>
    /// <param name="position">set release position</param>
    /// <param name="rotation">set release rotation</param>
    /// <returns></returns>
    public GameObject PreparedObject(Vector3 position,Quaternion rotation)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;

        return preparedObject;
    }
    /// <summary>
    /// override PreparedObject, and set PreparedObject position, rotation,scale
    /// </summary>
    /// <param name="position">set release position</param>
    /// <param name="rotation">set release rotation</param>
    /// <param name="localScale"> set release gameobject scale</param>
    /// <returns></returns>
    public GameObject PreparedObject(Vector3 position,Quaternion rotation ,Vector3 localScale)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        preparedObject.transform.localScale = localScale;

        return preparedObject;
    }
}
