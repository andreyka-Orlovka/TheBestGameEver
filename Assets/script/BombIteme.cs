
using UnityEngine;


public class BombIteme : MonoBehaviour
{
    public bool getKey1;
    public bool getKey2;
    public bool getKey3;

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            getKey1 = true;
            getKey2 = false;
            getKey3 = false;
        }
        if (Input.GetKeyDown("2"))
        {
            getKey1 = false;
            getKey2 = true;
            getKey3 = false;
        }
        if (Input.GetKeyDown("3"))
        {
            getKey1 = false;
            getKey2 = false;
            getKey3 = true;
        }
    }
}
