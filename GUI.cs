using Astra.info.HIIIII;
using System;
using UnityEngine;
using GorillaLocomotion;
using GorillaExtensions;
using BepInEx;
using PATCHESS;
using UnityEngine.InputSystem;

namespace ASTRAS.PULL.MOD.MAIN
{
    [BepInPlugin(INFO1.GUID, INFO1.Name, INFO1.Ver)]
    public class MAINCONTROLLER : BaseUnityPlugin
    {
        private Rect window = new Rect(200, 200, 250, 250);
      
        private static float pullPower = 0f;
        private static bool lasttouchleft;
        private static bool lasttouchright;
        public static bool RightGrab => ControllerInputPoller.instance.rightControllerGripFloat > 0.5f;
        public static void PullMod()
        {
            if (((!GTPlayer.Instance.IsHandTouching(true) && lasttouchleft) || (!GTPlayer.Instance.IsHandTouching(false) && lasttouchright)) && RightGrab)
            {
                Vector3 vel = GorillaTagger.Instance.rigidbody.linearVelocity;
                GTPlayer.Instance.transform.position += new Vector3(vel.x * pullPower, 0f, vel.z * pullPower);
            }
            lasttouchleft = GTPlayer.Instance.IsHandTouching(true);
            lasttouchright = GTPlayer.Instance.IsHandTouching(false);
        }

        public void OnGUI()
        {
         window = GUILayout.Window(1234234223, window, Main, "Astras Basic PULLMOD");
        }

        public void Main(int id)
        {
            GUILayout.Label("Change the slider to set the pullmod speed (use right grip)");
            pullPower = GUILayout.HorizontalSlider(pullPower, 0.001f, 5f);
            GUILayout.Label($"Speed set to {pullPower:F3}");
            
            GUI.DragWindow();

        }
        public void Update()
        {
            PullMod();
            
        }
        public void Start()
        {
            patches.Patchall();
        }
    }
}