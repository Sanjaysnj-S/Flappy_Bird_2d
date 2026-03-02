using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject perfabs;
    public float initialSpawn = 1.5f;
    public float minSpawn = 0.5f;
    public float decreaseSpawn = 0.01f;
    private float currentSpawn;
    //public float SpawnRate = 0.5f;
    public float minHeigt = -0.5f;
    public float maxHeigth = 0.5f;

    private void OnEnable()
    {
        currentSpawn = initialSpawn;
        InvokeRepeating(nameof(Spawn), currentSpawn, currentSpawn);
        InvokeRepeating(nameof(IncreaseDiffcuilt), 5f, 5f);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        GameObject Pipes = Instantiate(perfabs, transform.position, Quaternion.identity);
        Pipes.transform.position += Vector3.up * Random.Range(minHeigt, maxHeigth);
    }
    private void IncreaseDiffcuilt()
    {
        if (currentSpawn > minSpawn)
        {
            currentSpawn -= decreaseSpawn;
            //Debug.Log("Spawn rate increased: " + currentSpawn);


            //CancelInvoke(nameof(Spawn));
            //InvokeRepeating(nameof(Spawn), currentSpawn, currentSpawn);
        }
    }


}
