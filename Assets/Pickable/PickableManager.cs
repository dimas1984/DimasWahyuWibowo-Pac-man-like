using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    private List<Pickable> _picablelist = new List<Pickable>();
    // Start is called before the first frame update
    void Start()
    {
        InitPictableList();
    }

    private void InitPictableList() 
    {
        Pickable[] pickablesObjects = GameObject.FindObjectsOfType<Pickable>();
        for (int i=0; i< pickablesObjects.Length;i++)
        {
            _picablelist.Add(pickablesObjects[i]);
            pickablesObjects[i].OnPicked += OnPickaclePicked;
        }
        Debug.Log("Pickable List:"+ _picablelist.Count);
    }

    private void OnPickaclePicked(Pickable pickable) 
    { 
        _picablelist.Remove(pickable);
        // cek tipe pickable
        if(pickable.pickableType==PickableType.PowerUp)
        {
            _player?.PickPowerUp();
        }

       Debug.Log("Pickable List:" + _picablelist.Count);
        if (_picablelist.Count <= 0) 
        {
            Debug.Log("win");
        }
    }
    
  
}
