using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class dudeDespawn : MonoBehaviour
{
    // Use this for initialization
    public int time;
    public virtual void Start()
    {
        UnityEngine.Object.Destroy(this.gameObject, this.time);
    }

    public dudeDespawn()
    {
        this.time = 20;
    }

}