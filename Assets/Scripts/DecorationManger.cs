using UnityEngine;
using System.Collections.Generic;
using System;

public class DecorationManger : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    [SerializeField] private float spawnCooldown;
    private float spawn;

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform movingParent;
    [SerializeField] private Transform availableParent;
    [SerializeField] private List<GameObject> availableObjects;
    private List<GameObject> movingObjects = new List<GameObject>();

    void Start()
    {
        ObstacleManger.Accelerate += speedUp;
        foreach (Transform t in availableParent.GetComponentsInChildren<Transform>())
        {
            if (t.tag.Equals("Decoration"))
            {
                availableObjects.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        spawn += Time.deltaTime;
        if (spawn >= spawnCooldown)
        {
            spawn = 0;
            spawnRandom();
        }
    }

    private void spawnRandom()
    {
        if (availableObjects.Count == 0)
            return;
        int index = UnityEngine.Random.Range(0, availableObjects.Count - 1);
        GameObject go = availableObjects[index];
        go.SetActive(true);
        go.transform.position = new Vector3(spawnPosition.position.x, spawnPosition.position.y, go.transform.position.z);
        go.transform.parent = movingParent;
        go.GetComponent<Decoration>().SetManager(this, speed);
        movingObjects.Add(go);
        availableObjects.Remove(go);
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

    private void speedUp(float amount)
    {
        this.speed += amount;
    }

    void OnDisable()
    {
        ObstacleManger.Accelerate -= speedUp;
    }
}
