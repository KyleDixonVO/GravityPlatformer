using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayerPosition();
    }

    //Add lerp to this to add feeling of momentum
    void TrackPlayerPosition()
    {
        this.transform.position = new Vector3(PM.transform.position.x, PM.transform.position.y, transform.position.z);
    }


}
