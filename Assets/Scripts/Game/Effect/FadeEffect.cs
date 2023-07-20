using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class FadeEffect : MonoBehaviour
{
    [SerializeField] private Material effectMaterial;

    //カメラの画像がレンダリングされた直後に呼び出される
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial); //元のテクスチャをシェーダーでレンダリングするテクスチャへコピー
    }
}
