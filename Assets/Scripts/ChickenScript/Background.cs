using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Renderer renderer;
    private Material material;
    private float offset;
    [SerializeField] private float increase;
    [SerializeField] private float speed;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
    }

    private void FixedUpdate() {
        offset += increase;
        material.SetTextureOffset("_MainTex", new Vector2((offset * speed) / 1000, 0));
    }
}
