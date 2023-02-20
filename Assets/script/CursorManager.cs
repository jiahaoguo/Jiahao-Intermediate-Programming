
using UnityEngine;

public class CursorManager : MonoBehaviour
{


    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public GameObject hitParticle;
    public GameObject turretBase;
    public GameObject turret2;


    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
#else
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
#endif

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // << use GetMouseButton instead of GetMouseButtonDown
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                if (hit.transform.CompareTag("Enemy"))
                {

                    var a = Instantiate(hitParticle, new Vector3(hit.transform.position.x+0.1f, hit.transform.position.y, hit.transform.position.z), hit.transform.rotation);
                    hit.transform.GetComponent<Enemy>().health -= 10;
                    if (hit.transform.GetComponent<Enemy>().health > 0)
                    {
                        a.transform.SetParent(hit.transform);
                    }
                    SoundManager.Instance.sdHit.Play();
                }

                if (hit.transform.CompareTag("turretBase"))
                {
                    if (hit.transform.gameObject.GetComponent<turretBase>().occupied == false)
                    {
                        var a = Instantiate(turret2, hit.transform.position, transform.rotation);
                        
                        hit.transform.gameObject.GetComponent<turretBase>().occupied = true;
                    }
                }

            }
        }
    }
}
