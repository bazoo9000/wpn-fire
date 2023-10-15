using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraBerserkEffect : MonoBehaviour
{
    public Material _mat;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (!Berserk._isBerserk)
        {
            // normal rendering
            Graphics.Blit(src, dest);
            return;
        }

        // GUTS rendering
        Graphics.Blit(src, dest, _mat);
    }
}