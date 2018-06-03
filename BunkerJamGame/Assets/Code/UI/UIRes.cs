using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace JamGame.UI
{
    public class UIRes
    {
        public static GameObject LoadPrefab(string name)
        {
            string UIResRoot = "ui/";
            GameObject asset = (GameObject)Resources.Load(UIResRoot + name);
            return asset;
        }
    }
}
