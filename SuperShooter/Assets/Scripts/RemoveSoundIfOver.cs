using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class RemoveSoundIfOver : MonoBehaviour
{
    private float t;
    public virtual void Update()
    {
        if (this.GetComponent<AudioSource>())
        {
            if (((Time.time - this.t) > 5) && !this.GetComponent<AudioSource>().isPlaying)
            {
                UnityEngine.Object.Destroy(this.GetComponent<AudioSource>());
                UnityEngine.Object.Destroy(this);
            }
        }
        else
        {
            UnityEngine.Object.Destroy(this);
        }
    }

    public RemoveSoundIfOver()
    {
        this.t = Time.time;
    }

}