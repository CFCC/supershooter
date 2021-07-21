using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public partial class playerHealth : MonoBehaviour
{
    public string triggerTag;
    public GameObject destination;
    public GameObject objectToRelocate;
    public int startHealth;
    public Text healthGui;
    public Texture blood;
    public long timeNow;
    public GameObject rocketAmmoPrefab;
    public GameObject dudeAmmoPrefab;
    private long timeAtStart;
    private int currentHealth;

    public virtual void DropAmmo()
    {
        int n = 0;
        foreach (GunTrigger gunTrigger in this.GetComponents(typeof(GunTrigger)))
        {
            if (gunTrigger && (gunTrigger.ammoCount > 0))
            {
                Vector3 dropLocation = this.gameObject.transform.position;
                dropLocation.x = dropLocation.x + (n * 1f);
                GameObject ammoDrop = UnityEngine.Object.Instantiate(gunTrigger.ammoDropPrefab, dropLocation,
                    this.gameObject.transform.rotation);
                Ammo newAmmo = (Ammo) ammoDrop.GetComponentInChildren(typeof(Ammo));
                newAmmo.ammoQuantity = gunTrigger.ammoCount;
                newAmmo.ammoType = gunTrigger.ammoType;
                gunTrigger.ammoCount = 0;
            }

            n++;
        }
    }

    public virtual void Update()
    {
        if (healthGui != null)
        {
            healthGui.text = "Health: " + currentHealth;
            if (this.currentHealth <= 0)
            {
                this.DropAmmo();
                this.objectToRelocate.transform.position = this.destination.transform.position;
                this.currentHealth = this.startHealth;
            }
        }
    }


    public virtual void ApplyDamage(int number)
    {
        this.currentHealth = this.currentHealth - number;
        this.timeAtStart = System.DateTime.Now.Ticks;
    }

    public virtual void OnGUI()
    {
        // draws on mountain and in corner
        //Graphics.DrawTexture(Rect(10, 10, 100, 100), blood);
        if ((this.timeAtStart + 2000000) > this.timeNow)
        {
            GUI.DrawTexture(new Rect(1900, 10, -100, 800), this.blood);
            GUI.DrawTexture(new Rect(10, 10, 100, 800), this.blood);
        }

        this.timeNow = System.DateTime.Now.Ticks;
    }

    public playerHealth()
    {
        this.startHealth = 100;
        this.currentHealth = this.startHealth;
    }
}