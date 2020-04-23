using Assets.BuildSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Legacy UI script for the object builder
/// </summary>
public class ScriptDropDownInit : MonoBehaviour
{
    public string NameSpaceName = "ACE.FileSystem";
    private string currentString;
    Component compInSystem = null;
    Type[] typeArray;
    // Start is called before the first frame update
    void Start()
    {
        Dropdown dd = GetComponent<Dropdown>();
        List<Dropdown.OptionData> dropdownOptions = new List<Dropdown.OptionData>();
        typeArray = Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, NameSpaceName, StringComparison.Ordinal)).ToArray();
        foreach(Type t in typeArray)
        {
            string label = t.ToString();
            Dropdown.OptionData data = new Dropdown.OptionData();
            label = label.Remove(0, NameSpaceName.Length + 1);
            data.text = label;
            dropdownOptions.Add(data);
        }
        dd.options = dropdownOptions;
    }
    public void onStateChange()
    {
        if (compInSystem != null)
        {

        }
        Type classToAdd = typeArray[gameObject.GetComponent<Dropdown>().value];
        var classAdded = Activator.CreateInstance(classToAdd);
        ComponentHolder.AddComponent(classAdded as Component);
        compInSystem = classAdded as Component;
    }
    
}
