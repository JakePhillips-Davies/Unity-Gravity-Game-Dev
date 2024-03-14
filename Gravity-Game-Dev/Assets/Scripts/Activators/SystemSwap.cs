using Unity.Mathematics;
using UnityEngine;

public class SystemSwap : MonoBehaviour
{
    [Header("Ship Settings")]
    [SerializeField] Vector3 shipSpawnPos;
    [SerializeField] Vector3 shipSpawnRot;
    [SerializeField] GameObject ship;

    [Header("System Settings")]
    [SerializeField] GameObject system;

    public void Activate()
    {
        GameObject.FindWithTag("System").SetActive(false);

        system.SetActive(true);

        ship.transform.position = shipSpawnPos;
        ship.transform.eulerAngles = shipSpawnRot;
    }
}
