﻿using System.Linq;
using LSDR.InputManagement;
using UnityEngine;
using UnityEngine.UI;

namespace LSDR.UI.Settings
{
    /// <summary>
    /// Verifies a control scheme name.
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public class UIControlSchemeNameVerifier : MonoBehaviour
    {
        public ControlSchemeLoaderSystem ControlSchemeLoader;
        
        public Button Button;

        public bool CanHaveSameName
        {
            get
            {
                return _canHaveSameName;
            }
            set
            {
                _canHaveSameName = value;
                if (_canHaveSameName) Button.interactable = true;
            }
        }

        [SerializeField] private bool _canHaveSameName;

        [SerializeField] private InputField _inputField;

        void Awake()
        {
            _inputField = GetComponent<InputField>();
            _inputField.onValueChanged.AddListener(validateInput);
            Button.interactable = true;
        }

        /// <summary>
        /// Validate this control scheme name.
        /// </summary>
        /// <param name="input">The control scheme name.</param>
        /// <returns>False if invalid, true otherwise.</returns>
        public bool Validate(string input)
        {
            // scheme can't be empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // scheme can't overwrite another scheme
            if (!CanHaveSameName && ControlSchemeLoader.Schemes.Count(scheme => scheme.Name == input) > 0)
            {
                Debug.Log("Invalid");
                Debug.Log(CanHaveSameName);
                return false;
            }
            
            Debug.Log("Valid");

            return true;
        }

        private void validateInput(string input)
        {
            // set the button's state when the text changes
            Button.interactable = Validate(input);
        }
    }
}