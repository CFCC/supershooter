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
            int i = 0;
            obj = GameObject.Find("BowlingBall(Clone)");
            if (obj)
            {
                UnityEngine.Object.DestroyObject(obj);
            }
        }
    }

}