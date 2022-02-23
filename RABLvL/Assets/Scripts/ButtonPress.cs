using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public SimonSays simon;
    // place material items here

    public Material materialOriginal;

    public Material materialShift;

    public float pressedY;

    
    // Start is called before the first frame update
    void Start()
    {

     
        
    }

    // Update is called once per frame
    void Update()
    {

        // if button pressed command
        // change button color (material) for pressed vs unpressed
        //button press down yuh
        
    }

    public void Pressed ()
    {

        transform.position += new Vector3(0, pressedY, 0);

        GetComponent<Renderer>().material = materialShift;

    }

    public void Unpressed ()
    {

        transform.position += new Vector3(0, -pressedY, 0);

        GetComponent<Renderer>().material = materialOriginal;

        simon.OnButtonPress(this);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pressed();
        }

    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Unpressed();
        }

    }
}
