using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MaterialInventoryObject invetory;
    public Rigidbody2D rb;
    public float move_speed = 5f;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Debug.Log("Hi");
        var item = collision.GetComponent<MaterialItem>();
        if (item)
        {
            invetory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }*/
        if (collision.CompareTag("Material"))
        {
            Debug.Log("Hi");
            var item = collision.GetComponent<MaterialItem>();
            if (item)
            {
                invetory.AddItem(item.item, 1);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnApplicationQuit()
    {
        invetory.Container.Clear();
    }
}
