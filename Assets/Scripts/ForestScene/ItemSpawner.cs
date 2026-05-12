using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPool;

    public int numberOfSpawns;

    public GameObject [] childIndex;

    public bool spawnOnce;

    void Start()
    {
        childIndex = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childIndex[i] = transform.GetChild(i).gameObject;
        }

        Shuffle(childIndex);
        Shuffle(itemPool);
        Spawn();
    }
    public void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            // Pick a random index from 0 to i
            int randomIndex = Random.Range(0, i + 1);

            // Swap the elements
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void Spawn()
    {
        if (spawnOnce)
        {
            for (int i = 0;i < numberOfSpawns;i++)
            {
                Instantiate(itemPool[i], childIndex[i].transform.position - new Vector3 (0, 0.1f, 0), Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            }
        }
        else
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                Instantiate(itemPool[Random.Range(0, itemPool.Length)], childIndex[i].transform.position - new Vector3(0, 0.1f, 0), Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            }
        }
        
    }
}
