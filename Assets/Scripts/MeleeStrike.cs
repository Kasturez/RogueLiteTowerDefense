using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeStrike : MonoBehaviour
{
    float smooth = 20.0f;
    float attackSpeed = 2f;
    float triggered = 0f;
    float tiltAngle = 160.0f;
    BoxCollider2D objectCollider;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SwingWeapon(triggered);
        if (Input.GetMouseButton(0) && triggered == 0)
        {
            triggered = 1;
        }
        triggered = Mathf.Clamp(triggered - attackSpeed * Time.deltaTime, 0, 1);
        if (triggered == 0)
        {
            objectCollider.enabled = false;
        }
        objectCollider.enabled = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damageable")
        {
            Stats otherHealth = other.gameObject.GetComponent<Stats>();
            otherHealth.TakeDamage();
            Debug.Log(otherHealth.HP);
        }
    }
    private void SwingWeapon(float triggered)
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = triggered * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, -tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
