using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ScrollTexture : MonoBehaviour 
{

    [SerializeField] private int materialIndex = 0;
    [SerializeField] private Vector2 animationSpeed = new Vector2(0.0f, 5.0f);
    [SerializeField] private string textureName = "_MainTex";

    private Vector2 uvOffset = Vector2.zero;
    private MeshRenderer meshRenderer = null;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void LateUpdate()
    {
        uvOffset += (animationSpeed * Time.deltaTime);
        if (meshRenderer)
        {
            meshRenderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
