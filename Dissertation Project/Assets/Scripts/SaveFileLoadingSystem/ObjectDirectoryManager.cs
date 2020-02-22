using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Dummiesman;
namespace ACE.FileSystem
{
    
    public class ObjectDirectoryManager
    {
       public static GameObject LoadObject(string directory, string directoryName)
       {
            //Each directory consists of an object file, a material file a texture file and a manifest file
            // the texture and material files are optional
            // the mainfest and model is mandatory 
            // NOTE: Model be not be mandatory for script only objects
            //start off by loading the directory
            string[] filesInDirectory = Directory.GetFiles(directory);
            string objectName = "";
            string materialName = "";
            string manifestName = "";
            foreach(string i in filesInDirectory)
            {
                if(i.Split('.')[i.Split('.').Length - 1] == "obj")
                {
                    objectName = i;
                }
                if (i.Split('.')[i.Split('.').Length - 1] == "mtl")
                {
                    materialName = i;
                }
                if (i.Split('.')[i.Split('.').Length - 1] == "xml")
                {
                    manifestName = i;
                }
            }
            OBJLoader loader = new OBJLoader();
            FileStream stream = new FileStream(directory + "/" + directoryName +".obj" , FileMode.Open);
            FileStream mtlstream = new FileStream(directory + "/" + directoryName + ".mtl", FileMode.Open);
            if(filesInDirectory.Length > 3)
            {
                // we have a texture
                //TODO enable texture loading within the object manager.
            }
            return loader.Load(stream, mtlstream);

       }
    }
}
