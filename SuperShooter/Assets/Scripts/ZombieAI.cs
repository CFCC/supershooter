using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ZombieAI : MonoBehaviour
{
    private int startAtack;
    public int aggroDistance;
    public int health;
    public GameObject corpse;
    public int damage;
    public int moveSpeed;
    private GameObject targetPlayer;
    public virtual void Update()
    {
        int rotationSpeed = 5;
        int targetPlayerDistance = this.aggroDistance;
        Vector3 zombiePos = this.transform.position;
        //find everything thats near
        Collider[] colliders = Physics.OverlapSphere(zombiePos, this.aggroDistance);
        if (this.health != 100)
        {
            this.aggroDistance = 1000;
        }
        // loop through everything that we found to find players
        foreach (Collider hit in colliders)
        {
            if (hit == null)
            {
                continue;
            }
            if ((hit.gameObject.tag == "Player") || (hit.gameObject.name == "Decoy"))
            {
                // when we find a player, calculate the distance to that players
                float distance = Vector3.Distance(this.transform.position, hit.gameObject.transform.position);
                //if the player is closer than the previously found player than store it as the player to attack
                if ((distance <= this.aggroDistance) && ((this.targetPlayer != null) || (targetPlayerDistance >= distance)))
                {
                    this.targetPlayer = hit.gameObject;
                    targetPlayerDistance = (int) distance;
                }
            }
        }
        if (this.targetPlayer != null)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.targetPlayer.transform.position - this.transform.position), rotationSpeed * Time.deltaTime);
            if ((targetPlayerDistance <= 1.1f) && (this.targetPlayer.tag == "Player"))
            {
                if ((this.startAtack + 1) <= Time.time)
                {
                    this.startAtack = (int) Time.time;
                    this.targetPlayer.BroadcastMessage("ApplyDamage", this.damage);
                }
            }
            if (((targetPlayerDistance > 5) && (this.targetPlayer.name == "Decoy")) || ((this.targetPlayer.tag == "Player") && (targetPlayerDistance > 1)))
            {
                this.transform.position = this.transform.position + ((this.transform.forward * this.moveSpeed) * Time.deltaTime);
            }
        }
    }

    public virtual void OnExplosion(Vector3 explosionPosition)
    {
        int radius = 20;
        int maxDamage = 110;
        float distance = Vector3.Distance(this.transform.position, explosionPosition);
        float percentDamage = (radius - distance) / radius;
        percentDamage = Mathf.Max(percentDamage, 0);
        float damage = percentDamage * maxDamage;
        this.health = (int) (this.health - damage);
        if (this.health <= 0)
        {
            UnityEngine.Object.Instantiate(this.corpse, this.transform.position, this.transform.rotation);
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public ZombieAI()
    {
        this.aggroDistance = 15;
        this.health = 100;
        this.damage = 20;
        this.moveSpeed = 10;
    }

}