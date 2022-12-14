using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider strickrSlider;
    [SerializeField] private Transform strickerBg;
    [SerializeField] private float strickerSpeed;
    [SerializeField] float scaleValue;
    [SerializeField] private GameObject power;
    private bool strickerForce;
    private Rigidbody2D rb;
    RaycastHit2D hit;
    void Start()
    {
        power.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        strickrSlider.onValueChanged.AddListener(StrickerXPos); // call function when drag the slider for movement of the Stricker
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Call on mouseButton Click
        {
            power.SetActive(true);
             hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (hit.collider)
            {
                Debug.Log(scaleValue);
                if (hit.transform.name == "striker")
                {
                    strickerForce = false;
                }
                if (strickerForce)
                {
                    strickerBg.LookAt(hit.point);
                }
            }
            scaleValue = Vector2.Distance(transform.position, hit.point);
            strickerBg.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
        else if (Input.GetMouseButtonUp(0)) // Call on Mouse Button Release
        {
            power.SetActive(false);
            rb.AddForce(new Vector3(strickerBg.position.x - transform.position.x, strickerBg.position.y - transform.position.y, 0) * strickerSpeed, ForceMode2D.Impulse);
            strickerForce = false;
            strickerBg.localScale = Vector3.zero;
        }
    }
    // Function for Movement of the Stricker by Slider 
    public void StrickerXPos(float value)
    {
        transform.position = new Vector3(value, -0.5f, 0);
    }
}
