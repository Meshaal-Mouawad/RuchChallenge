using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WingsuitControler : MonoBehaviour
{
    public float speed = 20f;
    public TextMeshProUGUI countText;
    public float drag = 6f;
    public Rigidbody rb;
    public Vector3 rot;
    public float precentage;
    private int count;
    public GameObject winTextObject;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rot = transform.eulerAngles;
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

    }

    private void Update()
    {
     
        // Rotate the player
        // X
        rot.x += 20 * Input.GetAxis("Vertical") * Time.deltaTime;
        rot.x = Mathf.Clamp(rot.x, 0, 45);

        //Y=
        rot.y += 20 * Input.GetAxis("Horizontal") * Time.deltaTime;

        // Z
        rot.z = -5 * Input.GetAxis("Horizontal");
        rot.z = Mathf.Clamp(rot.z, -5, 5);
        transform.rotation = Quaternion.Euler(rot);

        precentage = rot.x / 45;
        // Drag: Fast(4) . slow(6)
        float mod_drag = (precentage * -2) + 6;
        // Speed: Fast(a3.8) , slow(12.5) 
        float mod_speed = precentage * (13.8f - 12.5f) + 12.5f;

        rb.drag = mod_drag;
        Vector3 localV = transform.InverseTransformDirection(rb.velocity);
        localV.z = mod_speed;
        rb.velocity = transform.TransformDirection(localV);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }

        count = count + 1;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 4)
        {
            winTextObject.SetActive(true);
        }
    }

}
