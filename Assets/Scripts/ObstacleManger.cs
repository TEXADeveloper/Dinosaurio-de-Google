using UnityEngine;
using System.Collections.Generic;

public class ObstacleManger : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform movingParent;
    [SerializeField] private Transform availableParent;
    [SerializeField] private List<GameObject> availableObjects;
    private List<GameObject> movingObjects;

    void Start()
    {
        foreach (Obstacle t in availableParent.GetComponentsInChildren<Obstacle>())
            availableObjects.Add(t.gameObject);
    }

    private void spawnRandom()
    {
        if (availableObjects.Count == 0)
            return;
        int index = Random.Range(0, availableObjects.Count - 1);
        availableObjects[index].transform.position = spawnPosition.position;
        availableObjects[index].transform.parent = movingParent;
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
}
