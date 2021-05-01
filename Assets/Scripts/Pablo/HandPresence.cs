using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics ControllerCharacteristics;
    public GameObject HandModelPrefab;

    private GameObject spawnedHandModel;
    private InputDevice targetDevice;
    private Animator HandAnimator;

    // Start is called before the first frame update
    void Start()
    {
        TryInitiatize();
    }

    private void TryInitiatize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            spawnedHandModel = Instantiate(HandModelPrefab, transform);
            HandAnimator = spawnedHandModel.GetComponent<Animator>();
        }
        
    }
       
    // Update is called once per frame
    void Update()
    {
        /*if (!targetDevice.isValid)
        {
            TryInitiatize();
        }
        else
        {
            UpdateHandAnimation();
        }*/

        UpdateHandAnimation();
    }

    public void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {

            HandAnimator.SetFloat("Trigger", triggerValue);
        }
        else 
        {
            //HandAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float GripValue))
        {
            HandAnimator.SetFloat("Grip", GripValue);
        }
        else
        {
            //HandAnimator.SetFloat("Grip", 0);
        }
    }
}
