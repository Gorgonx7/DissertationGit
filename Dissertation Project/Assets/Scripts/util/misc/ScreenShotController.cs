using SFB;
using System.IO;
using UnityEngine;

/// <summary>
/// Responsible for saving a screenshot of a room after it has been created
/// </summary>
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
    public void FolderSelectCamCapture()
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

        string[] folderLocation = StandaloneFileBrowser.OpenFolderPanel("Select location to save screenshot", "./", false);
        
        if (folderLocation.Length < 1)
        {
            return;
        }
        File.WriteAllBytes(folderLocation[0] + "screenshot.png", Bytes);
    }
    public static Texture2D LoadTexture(string fileLocation)
    {
       
        byte[] textureInfo = File.ReadAllBytes(fileLocation);
       
        Texture2D output = new Texture2D(2, 2, TextureFormat.RGBA32, false) ;
        output.LoadImage(textureInfo);
        return output;

    }
}
