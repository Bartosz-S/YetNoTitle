using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlayersOutOfBondsCheck()
    {

        return true;
    }
}
