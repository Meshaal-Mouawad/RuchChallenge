using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* How to use:
* 1- Attach this script to the camera
* 2- Make sure the camera is a child of your player
* 3- Attach the player's 'WingsuitController' script to the 'wc' variable
* 4- You can adjust the 'shaking' variable, which is the value of how much can the camera shake (Optional)
*/

public class CameraShake : MonoBehaviour
{
    // The wingsuit script that the player has
    public WingsuitControler wc;
    
    // The amount of shaking
    public float shaking = 0.5f;

    private void LateUpdate()
    {
        // Will affect the shaking based on the player's x rotation
        float mod_shaking = shaking * wc.precentage; // we call the variable precentage from WingsuitControler
        // Give the camera a random position based on the percentage and shaking variables
        transform.localPosition = new Vector3(Random.Range(-mod_shaking, mod_shaking), Random.Range(-mod_shaking, mod_shaking), 0);
    }
}