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

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, devices);

        spawnedHandModel = Instantiate(HandModelPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
