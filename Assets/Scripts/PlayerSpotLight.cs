using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.HighDefinition;

public class PlayerSpotLight : MonoBehaviour
{
    public GameObject spot_LightObject;
    [SerializeField] private movementTest playerScript;
    HDAdditionalLightData lightData;




    // Start is called before the first frame update
    void Start()
    {
        spotLightData(40000f, 179f, 100);
        
    }

    // Update is called once per frame
    void Update()
    { 
    switch (playerScript.buttonsFilled)
        {
            case 0: spotLightData(25000f, 179f, 100); break;
            case 1: spotLightData(20000f, 100f, 100); break;
            case 2: spotLightData(18000f, 87f, 90); break;
            case 3: spotLightData(18000f, 77f, 80); break;
            case 4: spotLightData(18000f, 68f, 75); break;
            case 5: spotLightData(18000f, 60f, 75); break;
            case 6: spotLightData(18000f, 52f, 75); break;
            case 7: spotLightData(22000f, 45f, 75); break;
            case 8: spotLightData(25000f, 39f, 75); break;
            case 9: spotLightData(27000f, 34f, 75); break;
            case 10: spotLightData(30000f, 30f, 75); break;
            default: spotLightData(40000f, 179f, 100); break;
        }

    }
    void spotLightData(float inten, float coneAngle, float innerPercent)
    {
        lightData = spot_LightObject.GetComponent<HDAdditionalLightData>();
        lightData.intensity = inten;
        lightData.SetSpotAngle(coneAngle, innerPercent);
    }
}
