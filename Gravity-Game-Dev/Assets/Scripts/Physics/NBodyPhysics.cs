using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodyPhysics : MonoBehaviour
{
    public struct AstroBody
    {
        public Vector3 position;
        public Vector3 force;
        public float mass;
    };
    int AstroBodySize;


    public const float gravitationalConstant = 1f;
    Bodies[] bodies;
    AstroBody[] data;
    public ComputeShader computeShader;
    

    void Awake()
    {
        int massSize = sizeof(float);
        int posSize = sizeof(float) * 3;
        int forceSize = sizeof(float) * 3;
        AstroBodySize = massSize + posSize + forceSize;
    }

    void FixedUpdate()
    {
        bodies = GameObject.FindObjectsOfType<Bodies>();
        data = new AstroBody[bodies.Length];

        for(int i = 0; i < bodies.Length; i++) {
            data[i].position = bodies[i].tm.position;
            data[i].mass = bodies[i].rb.mass;
        }

        ComputeBuffer astroBodyBuffer = new ComputeBuffer(data.Length, AstroBodySize);
        astroBodyBuffer.SetData(data);

        computeShader.SetBuffer(0, "astroBodies", astroBodyBuffer);
        computeShader.SetInt("arrayLength", data.Length);
        computeShader.Dispatch(0, 128, 1, 1);

        astroBodyBuffer.GetData(data);

        for(int i = 0; i < bodies.Length; i++) {
            bodies[i].rb.AddForce(data[i].force);
        }

        astroBodyBuffer.Release();
    }
}