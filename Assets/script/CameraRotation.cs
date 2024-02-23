using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Transform cameraAxic;
    
    //минимальный угл поворота 
    [SerializeField] private float minAngle;
    
    //максимальный угл поворота
    [SerializeField] private float maxAngle;
    
    


    void Update()
    {
        //поворот камеры по y
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse X"), 0);
        
        
        //поворот камеры по x
        var newAnglesX = cameraAxic.localEulerAngles.x - Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse Y");
        if (newAnglesX > 180)
        {
            newAnglesX -= 360;
        }
        newAnglesX = Mathf.Clamp(newAnglesX, minAngle, maxAngle);
        cameraAxic.localEulerAngles = new Vector3(newAnglesX, 0, 0);
        
            
    }
}
