using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class despawn : MonoBehaviour
{
    // Use this for initialization
    public int time;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        this.GetComponent<Collider>().isTrigger = true;
        UnityEngine.Object.Destroy(this.gameObject, this.time);
    }

    public despawn()
    {
        this.time = 5;
    }

}