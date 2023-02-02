using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float attackRate;
    private float nextAttackTime = 0f;

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}
