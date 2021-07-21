using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Startup : MonoBehaviour
{
    public virtual void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            GameObject obj = null;
            obj = GameObject.Find("BowlingBall(Clone)");
            if (obj)
            {
                Destroy(obj);
            }
        }
    }

}