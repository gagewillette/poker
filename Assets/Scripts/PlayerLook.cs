using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensX;
    public float sensY;
    
    public Transform orientation;

    private float xRotation;
    private float yRotation;

    private int frameDelay = 0;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        //yRotation = Mathf.Clamp(yRotation, -360, -90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            frameDelay++;
            if (frameDelay < 60)
                return;
            
            if (!hit.transform.name.Contains("CasinoChip"))
                return;    
            if (Input.GetMouseButton(0))
            {
                if (!hit.transform.name.Contains("CasinoChip"))
                    return;   
            
                Debug.Log("Clicking at chip");
                return;
            }

            Outline obj = hit.transform.GetComponent<Outline>();
            
            obj.enabled = !obj.enabled;
            
            Debug.Log("Looking at chip");
        }
    }
}
