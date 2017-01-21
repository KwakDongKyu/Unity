using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLocationController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Creature")
        {
            Destroy(other.gameObject);
        }
    }
}
