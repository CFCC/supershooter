using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Ammo : MonoBehaviour
{
    public string ammoType;
    public int ammoQuantity;
    public GameObject pickupSound;
    public Ammo()
    {
        this.ammoType = "Rockets";
        this.ammoQuantity = 10;
    }

}