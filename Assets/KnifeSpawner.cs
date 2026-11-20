using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knife;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public CarrotMovement logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Carrot").GetComponent<CarrotMovement>();
    }

    void Update()
    {
        if (logic.gameNotOver == false)
        {
            return;
        }
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            spawnKnife();
            timer = 0;
        }
        
    }
    void spawnKnife()
    {
                
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(knife, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
