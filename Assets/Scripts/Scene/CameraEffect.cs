using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public Shader shader;
    public Camera cameraAffected;

    void Update()
    {
        cameraAffected.SetReplacementShader(shader, "RenderType");
    }
}
