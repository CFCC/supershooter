using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public partial class GunTrigger : MonoBehaviour
{
    public float fireRate;
    public GameObject projectilePrefab;
    public GameObject projectileSpawn;
    public int projectileSpeed;
    public bool projectileOrientToPlayer;
    public string inputButtonString;
    public int ammoCount;
    public Text ammoLabel;
    public string ammoType;
    public AudioClip ammoPickupSound;
    public GameObject ammoDropPrefab;
    public GameObject player;
    private float lastFire;
    public virtual void OnGUI()
    {
        if (this.ammoLabel)
        {
            this.ammoLabel.text = (this.ammoType + ": ") + this.ammoCount;
        }
    }

    public virtual void FixedUpdate()
    {
        // Pickup appropriate ammo
        GameObject[] ammoPacks = GameObject.FindGameObjectsWithTag("Ammo");
        foreach (GameObject ammoPackObject in ammoPacks)
        {
            Vector3 pos = this.player.transform.position;
            Quaternion rot = this.player.transform.rotation;
            float dist = Vector3.Distance(pos, ammoPackObject.transform.position);
            Ammo ammoPack = (Ammo) ammoPackObject.GetComponent(typeof(Ammo));
            if ((dist < 3f) && (ammoPack.ammoType == this.ammoType))
            {
                UnityEngine.Object.Instantiate(ammoPack.pickupSound, pos, rot);
                this.ammoCount = this.ammoCount + ammoPack.ammoQuantity;
                UnityEngine.Object.Destroy(ammoPackObject);
            }
        }
        // Fire Weapon
        if (Input.GetButton(this.inputButtonString) && (this.ammoCount > 0))
        {
            float t = Time.time;
            if ((this.lastFire + this.fireRate) < t)
            {
                Transform trans = this.projectileSpawn.transform;
                GameObject projectile = UnityEngine.Object.Instantiate(this.projectilePrefab, trans.position, this.projectileOrientToPlayer ? trans.rotation : Quaternion.identity);
                if (this.ammoType == "Dudes")
                {
                    projectile.name = "Decoy";
                }
                ((Rigidbody) projectile.GetComponent(typeof(Rigidbody))).velocity = this.projectileSpawn.transform.forward * this.projectileSpeed;
                this.ammoCount = this.ammoCount - 1;
                this.lastFire = t;
            }
        }
    }

    public GunTrigger()
    {
        this.fireRate = 2f;
        this.projectileSpeed = 10;
        this.inputButtonString = "Fire1";
        this.ammoCount = 10;
        this.ammoType = "Rockets";
        this.lastFire = -10000f;
    }

}