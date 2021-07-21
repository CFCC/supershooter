using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MoveOnCollide : MonoBehaviour
{
    public string triggerTag;
    public GameObject destination;
    public GameObject objectToRelocate;
    public virtual void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == this.triggerTag)
        {
            this.objectToRelocate.transform.position = this.destination.transform.position;
        }
    }

}