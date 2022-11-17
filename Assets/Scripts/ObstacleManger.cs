using UnityEngine;
using System.Collections.Generic;
using System;

public class ObstacleManger : MonoBehaviour
{
    public static event Action<float> Accelerate;
    [SerializeField] private float speed = 5;
    [SerializeField] private float accelerationAmount = 0.3f;
    [SerializeField] private float maxSpeed = 15;

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform movingParent;
    [SerializeField] private Transform availableParent;
    [SerializeField] private List<GameObject> availableObjects;
    private List<GameObject> movingObjects = new List<GameObject>();

    void Start()
    {
        foreach (Transform t in availableParent.GetComponentsInChildren<Transform>())
        {
            if (t.tag.Equals("Obstacle"))
            {
                availableObjects.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
    }

    public void SpawnRandom()
    {
        if (availableObjects.Count == 0)
            return;
        int index = UnityEngine.Random.Range(0, availableObjects.Count - 1);
        availableObjects[index].SetActive(true);
        availableObjects[index].transform.position = spawnPosition.position;
        availableObjects[index].transform.parent = movingParent;
        availableObjects[index].GetComponent<Obstacle>().SetManager(this, speed);
        movingObjects.Add(availableObjects[index]);
        availableObjects.Remove(availableObjects[index]);
    }

    public void Despawn(GameObject caller)
    {
        if (!movingObjects.Contains(caller))
            return;
        availableObjects.Add(caller);
        caller.transform.parent = availableParent;
        movingObjects.Remove(caller);
        caller.SetActive(false);
    }

    public void SpeedUp()
    {
        if ((speed + accelerationAmount) <= maxSpeed)
        {
            speed += accelerationAmount;
            Accelerate?.Invoke(accelerationAmount);
        }
    }
}
