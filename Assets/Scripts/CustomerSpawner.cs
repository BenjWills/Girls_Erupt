using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerObject;
    public float[] customerSpawnNumb;
    private float customerSpawnedNUmbPicked;
    private int numbPicked;
    public float currentSpawned;
    private bool minusHappened;
    public float customerSpawnTimer;
    [SerializeField] private float customerMaxSpawn = 42;
    public bool canSpawn;

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
        customerSpawnedNUmbPicked = customerSpawnNumb[numbPicked];
        while (customerSpawnedNUmbPicked != currentSpawned)
        {
            if (minusHappened == false)
            {
                customerMaxSpawn -= customerSpawnedNUmbPicked;
                minusHappened = true;
            }
            Instantiate(customerObject, this.gameObject.transform);
            currentSpawned += 1;
            yield return new WaitForSeconds(customerSpawnTimer);
        }
        if (customerSpawnedNUmbPicked == currentSpawned)
        {
            canSpawn = false;
        }
    }
}
