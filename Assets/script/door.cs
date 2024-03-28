
using script.bomb;
using script.игрок;
using UnityEngine;

public class door : MonoBehaviour
{

    public GameObject WIN;
    public GameObject gameplayUI;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            gameplayUI.SetActive(false);
            WIN.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<PlayerHp>().enabled = false;
        }
    }
}
