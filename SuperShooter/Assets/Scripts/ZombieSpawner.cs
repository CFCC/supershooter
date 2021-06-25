using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public int spawnRate;
    private int lastzombiespawn;
    public virtual void Awake()
    {
    }

    public virtual void Update()
    {
        float dif = Time.time - this.lastzombiespawn;
        if (dif > this.spawnRate)
        {
            Vector3 position = new Vector3(Random.Range(100, 200), 10, Random.Range(100, 200));
            GameObject newZombie = UnityEngine.Object.Instantiate(this.zombie, position, Quaternion.identity);
            Component zombieAI = newZombie.GetComponent("ZombieAI");
            this.lastzombiespawn = (int) Time.time;
        }
    }

    public ZombieSpawner()
    {
        this.spawnRate = 5;
    }

}