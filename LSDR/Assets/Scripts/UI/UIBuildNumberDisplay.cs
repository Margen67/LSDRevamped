﻿using UnityEngine;
using UnityEngine.UI;

namespace LSDR.UI
{
	/// <summary>
	/// Display the build number on text at the top of the screen.
	/// </summary>
    public class UIBuildNumberDisplay : MonoBehaviour
	{
		public Text BuildNumberText;

        void Start()
        {
            BuildNumberText.text = typeof(UIBuildNumberDisplay).Assembly.GetName().Version.ToString();
        }
    }
}
