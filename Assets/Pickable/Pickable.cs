using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    [SerializeField] public PickableType pickableType;
    public Action<Pickable> OnPicked;
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Pickup" + pickableType);
            OnPicked(this);
            //Debug.Log("Trigger");
            Destroy(gameObject);
        }
        
    }
}
