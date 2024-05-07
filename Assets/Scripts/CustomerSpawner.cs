using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerObject;
    public float[] customerSpawnNumb;
    private int numbPicked;
    public float currentSpawned;
    private bool minusHappened;
    public float customerSpawnTimer;
    private float customerMaxSpawn = 42;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        minusHappened = false;
    }

    public void StartSpawning()
    {
        if (canSpawn == true)
        {
            canSpawn = false;
            StartCoroutine(CustomerSpawn());
        }
    }

    IEnumerator CustomerSpawn()
    {
        numbPicked = Random.Range(0, 3);
        while (customerSpawnNumb[numbPicked] != currentSpawned)
        {
            if (minusHappened == false)
            {
                customerMaxSpawn -= customerSpawnNumb[numbPicked];
                minusHappened = true;
            }
            Instantiate(customerObject, this.gameObject.transform);
            currentSpawned += 1;
            yield return new WaitForSeconds(customerSpawnTimer);
        }
        if (customerSpawnNumb[numbPicked] == currentSpawned)
        {
            canSpawn = true;
        }
    }
}
