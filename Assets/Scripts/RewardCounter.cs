using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardCounter : MonoBehaviour
{
    //private PlayerJump playerJumpScript;
    [SerializeField] private Text coincounter;
    private int coinCollected = 0;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //playerJumpScript.soundManager.PlaycoinCollect();
            Destroy(other.gameObject);
            coinCollected++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        coincounter.text = ("" + coinCollected);
        
    }
}
