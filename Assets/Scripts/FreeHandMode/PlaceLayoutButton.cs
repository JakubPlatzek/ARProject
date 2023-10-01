using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlaceLayoutButton : MonoBehaviour
    {
        public bool pressed;

        private void Start()
        {
            gameObject.SetActive(true);
            GetComponent<Button>().onClick.AddListener(Press);
        }

        public void Press()
        {
            pressed = true;
            Invoke("Unpress", 1f);
        }

        public void Unpress()
        {
            pressed = false;
        }
    }
}