using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] float m_forceFactor = 3.0f;
    [SerializeField] float m_cooldown = 1.0f;

    private float m_lastTimeShot = 0f;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > m_lastTimeShot + m_cooldown)
        {
            m_lastTimeShot = Time.time;
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            Vector3 movDir = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;
            rb.AddForce(m_forceFactor * movDir, ForceMode.Impulse);
            Destroy(bullet, 2.0f);
        }
    }
}
