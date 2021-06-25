using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class guyExplosion : MonoBehaviour
{
    public GameObject explosion;
    public bool causesExplosion;
    public GameObject model;
    public int colideCount;
    public bool collided;
    public virtual void Start()
    {
        this.Invoke("Explode", 12.2f);
    }

    public virtual void Explode()
    {
        if (this.causesExplosion)
        {
            GameObject newexplosion = UnityEngine.Object.Instantiate(this.explosion, this.gameObject.transform.position, Random.rotation);
            float radius = 75f;
            float power = 10000f;
            Vector3 explosionPos = this.gameObject.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit == null)
                {
                    continue;
                }
                if (!hit.isTrigger && hit.GetComponent<Rigidbody>())
                {
                    hit.gameObject.SendMessage("OnExplosion", explosionPos, SendMessageOptions.DontRequireReceiver);
                }
            }
            colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit == null)
                {
                    continue;
                }
                if (!hit.isTrigger && hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 0);
                }
            }
        }
        this.Invoke("DestroyNow", 0);
    }

    public virtual void DestroyNow()
    {
        UnityEngine.Object.DestroyObject(this.gameObject);
    }

}