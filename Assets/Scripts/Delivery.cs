using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("entered in trigger event");
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("XX" + collision.gameObject.tag + "XX");
            Debug.Log("picked up");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("XX" + collision.gameObject.tag + "XX");
            Debug.Log("Delivered");
            Destroy(collision.gameObject, destroyDelay);
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
