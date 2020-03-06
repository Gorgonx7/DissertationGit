using System.IO;
using UnityEngine;

public class ScreenShotController : MonoBehaviour
{

    public void CamCapture(string FileLocation)
    {
        Camera Cam = GetComponent<Camera>();

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        File.WriteAllBytes(FileLocation + "screenshot.png", Bytes);
        
    }

}
