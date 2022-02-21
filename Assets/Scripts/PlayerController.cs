using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float aimDistance;
    public GameObject mainCam;
    public GameObject door;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        UpdateAim();
    }
    private void UpdateAim()
    {
        RaycastHit hit;
        var forward = UIManager.Instance.aim.transform.TransformDirection(Vector3.forward);
        Ray ray = Camera.main.ScreenPointToRay(UIManager.Instance.aim.transform.position);
        //Ray ray = new Ray(transform.position, forward);
        Debug.DrawRay(UIManager.Instance.aim.transform.position, forward, Color.green);
        if (Physics.Raycast(ray, out hit, aimDistance))
        {
            if (hit.collider.CompareTag("door"))
            {
                UIManager.Instance.aim.color = Color.red;
                UIManager.Instance.doorBtn.SetActive(true);
                door = hit.collider.gameObject;
            }
            else
            {
                UIManager.Instance.aim.color = Color.white;
                UIManager.Instance.doorBtn.SetActive(false);
                door = null;
            }
        }
        else
        {
            UIManager.Instance.doorBtn.SetActive(false);
            UIManager.Instance.aim.color = Color.white;
            door = null;
        }
    }

    public void OpenDoor()
    {
        door.GetComponent<DoorHandler>().OpenCloseDoor();
    }
}
