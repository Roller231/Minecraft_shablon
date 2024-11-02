using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TntExp : MonoBehaviour
{

	public float radius;
	public float force;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.E))
	    {
		    Collider[] col = Physics.OverlapSphere(transform.position, radius);
		    gameObject.GetComponent<AudioSource>().Play();
		    foreach (var c in col)
		    {
			    if (c.gameObject.layer != 7 && c.tag != "Player")
			    {
				    c.GetComponent<Rigidbody>().isKinematic = false;
				    c.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
				    if (c.tag == "Cube")
				    {
					    c.GetComponent<Cube>().enabled = false;
					    Destroy(c.gameObject, 4f);
				    }
				    else if (c.tag == "Enemy")
				    {
					    
					    Destroy(c.gameObject, 1);
				    }


			    }

		    }
		    Destroy(gameObject, 1);
	    }
    }

    private void OnDrawGizmosSelected()
    {
	    Gizmos.color = Color.blue;
	    Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void ExplosionButton()
    {
	    Collider[] col = Physics.OverlapSphere(transform.position, radius);
	    gameObject.GetComponent<AudioSource>().Play();
	    foreach (var c in col)
	    {
		    if (c.gameObject.layer != 7 && c.tag != "Player")
		    {
			    c.GetComponent<Rigidbody>().isKinematic = false;
			    c.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
			    if (c.tag == "Cube")
			    {
				    c.GetComponent<Cube>().enabled = false;
				    Destroy(c.gameObject, 4f);
			    }
			    else if (c.tag == "Enemy")
			    {
					    
				    Destroy(c.gameObject, 1);
			    }


		    }

	    }
	    Destroy(gameObject, 1);
    }
}
