using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ExplodeOnContact : MonoBehaviour
{
    public GameObject explosion;
    public bool causesExplosion;
    public GameObject model;
    public int colideCount;
    public bool collided;
    public virtual void OnCollisionEnter(Collision c)
    {
        if (!this.collided && (c.contacts.Length > 0))
        {
            this.collided = true;
            ContactPoint contact = c.contacts[0];
            Collider collider = (Collider) this.GetComponent(typeof(Collider));
            Renderer renderer = (Renderer) this.model.GetComponent(typeof(Renderer));
            UnityEngine.Object.DestroyObject(this.model);
            collider.isTrigger = true;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Quaternion rot = Random.rotation;
            UnityEngine.Object.Instantiate(this.explosion, contact.point + (contact.normal * 0), rot);
            if (this.causesExplosion)
            {
                float radius = 20f;
                float power = 5000f;
                Vector3 explosionPos = this.transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
                foreach (Collider hit in colliders)
                {
                    if (hit == null)
                    {
                        continue;
                    }
                    if (!hit.isTrigger && hit.GetComponent<Rigidbody>())
                    {
                        hit.gameObject.SendMessage("OnExplosion", contact.point, SendMessageOptions.DontRequireReceiver);
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
        }
        this.Invoke("DestroyNow", 3);
    }

    public virtual void DestroyNow()
    {
        UnityEngine.Object.DestroyObject(this.gameObject);
    }

}