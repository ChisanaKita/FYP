//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Action_Boolean p_default_InteractUI;
        
        private static SteamVR_Action_Boolean p_default_Teleport;
        
        private static SteamVR_Action_Boolean p_default_GrabPinch;
        
        private static SteamVR_Action_Boolean p_default_GrabGrip;
        
        private static SteamVR_Action_Pose p_default_Pose;
        
        private static SteamVR_Action_Skeleton p_default_SkeletonLeftHand;
        
        private static SteamVR_Action_Skeleton p_default_SkeletonRightHand;
        
        private static SteamVR_Action_Single p_default_Squeeze;
        
        private static SteamVR_Action_Boolean p_default_HeadsetOnHead;
        
        private static SteamVR_Action_Boolean p_default_SnapTurnLeft;
        
        private static SteamVR_Action_Boolean p_default_SnapTurnRight;
        
        private static SteamVR_Action_Vibration p_default_Haptic;
        
        private static SteamVR_Action_Boolean p_vRF_UI;
        
        private static SteamVR_Action_Boolean p_vRF_PullTrigger;
        
        private static SteamVR_Action_Boolean p_vRF_Menu;
        
        private static SteamVR_Action_Boolean p_vRF_D_Up;
        
        private static SteamVR_Action_Boolean p_vRF_D_Left;
        
        private static SteamVR_Action_Boolean p_vRF_D_Down;
        
        private static SteamVR_Action_Boolean p_vRF_D_Right;
        
        private static SteamVR_Action_Boolean p_vRF_Grab;
        
        private static SteamVR_Action_Skeleton p_vRF_SkeletonLeftHand;
        
        private static SteamVR_Action_Skeleton p_vRF_SkeletonRightHand;
        
        private static SteamVR_Action_Pose p_vRF_Pose;
        
        private static SteamVR_Action_Vibration p_vRF_Haptic;
        
        public static SteamVR_Action_Boolean default_InteractUI
        {
            get
            {
                return SteamVR_Actions.p_default_InteractUI.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_Teleport
        {
            get
            {
                return SteamVR_Actions.p_default_Teleport.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_GrabPinch
        {
            get
            {
                return SteamVR_Actions.p_default_GrabPinch.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_GrabGrip
        {
            get
            {
                return SteamVR_Actions.p_default_GrabGrip.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Pose default_Pose
        {
            get
            {
                return SteamVR_Actions.p_default_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }
        
        public static SteamVR_Action_Skeleton default_SkeletonLeftHand
        {
            get
            {
                return SteamVR_Actions.p_default_SkeletonLeftHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Skeleton default_SkeletonRightHand
        {
            get
            {
                return SteamVR_Actions.p_default_SkeletonRightHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Single default_Squeeze
        {
            get
            {
                return SteamVR_Actions.p_default_Squeeze.GetCopy<SteamVR_Action_Single>();
            }
        }
        
        public static SteamVR_Action_Boolean default_HeadsetOnHead
        {
            get
            {
                return SteamVR_Actions.p_default_HeadsetOnHead.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_SnapTurnLeft
        {
            get
            {
                return SteamVR_Actions.p_default_SnapTurnLeft.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_SnapTurnRight
        {
            get
            {
                return SteamVR_Actions.p_default_SnapTurnRight.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Vibration default_Haptic
        {
            get
            {
                return SteamVR_Actions.p_default_Haptic.GetCopy<SteamVR_Action_Vibration>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_UI
        {
            get
            {
                return SteamVR_Actions.p_vRF_UI.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_PullTrigger
        {
            get
            {
                return SteamVR_Actions.p_vRF_PullTrigger.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_Menu
        {
            get
            {
                return SteamVR_Actions.p_vRF_Menu.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_D_Up
        {
            get
            {
                return SteamVR_Actions.p_vRF_D_Up.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_D_Left
        {
            get
            {
                return SteamVR_Actions.p_vRF_D_Left.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_D_Down
        {
            get
            {
                return SteamVR_Actions.p_vRF_D_Down.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_D_Right
        {
            get
            {
                return SteamVR_Actions.p_vRF_D_Right.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean vRF_Grab
        {
            get
            {
                return SteamVR_Actions.p_vRF_Grab.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Skeleton vRF_SkeletonLeftHand
        {
            get
            {
                return SteamVR_Actions.p_vRF_SkeletonLeftHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Skeleton vRF_SkeletonRightHand
        {
            get
            {
                return SteamVR_Actions.p_vRF_SkeletonRightHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Pose vRF_Pose
        {
            get
            {
                return SteamVR_Actions.p_vRF_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }
        
        public static SteamVR_Action_Vibration vRF_Haptic
        {
            get
            {
                return SteamVR_Actions.p_vRF_Haptic.GetCopy<SteamVR_Action_Vibration>();
            }
        }
        
        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_Teleport,
                    SteamVR_Actions.default_GrabPinch,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand,
                    SteamVR_Actions.default_Squeeze,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_SnapTurnLeft,
                    SteamVR_Actions.default_SnapTurnRight,
                    SteamVR_Actions.default_Haptic,
                    SteamVR_Actions.vRF_UI,
                    SteamVR_Actions.vRF_PullTrigger,
                    SteamVR_Actions.vRF_Menu,
                    SteamVR_Actions.vRF_D_Up,
                    SteamVR_Actions.vRF_D_Left,
                    SteamVR_Actions.vRF_D_Down,
                    SteamVR_Actions.vRF_D_Right,
                    SteamVR_Actions.vRF_Grab,
                    SteamVR_Actions.vRF_SkeletonLeftHand,
                    SteamVR_Actions.vRF_SkeletonRightHand,
                    SteamVR_Actions.vRF_Pose,
                    SteamVR_Actions.vRF_Haptic};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_Teleport,
                    SteamVR_Actions.default_GrabPinch,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand,
                    SteamVR_Actions.default_Squeeze,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_SnapTurnLeft,
                    SteamVR_Actions.default_SnapTurnRight,
                    SteamVR_Actions.vRF_UI,
                    SteamVR_Actions.vRF_PullTrigger,
                    SteamVR_Actions.vRF_Menu,
                    SteamVR_Actions.vRF_D_Up,
                    SteamVR_Actions.vRF_D_Left,
                    SteamVR_Actions.vRF_D_Down,
                    SteamVR_Actions.vRF_D_Right,
                    SteamVR_Actions.vRF_Grab,
                    SteamVR_Actions.vRF_SkeletonLeftHand,
                    SteamVR_Actions.vRF_SkeletonRightHand,
                    SteamVR_Actions.vRF_Pose};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[] {
                    SteamVR_Actions.default_Haptic,
                    SteamVR_Actions.vRF_Haptic};
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[] {
                    SteamVR_Actions.default_Haptic,
                    SteamVR_Actions.vRF_Haptic};
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.vRF_Pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_Teleport,
                    SteamVR_Actions.default_GrabPinch,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_SnapTurnLeft,
                    SteamVR_Actions.default_SnapTurnRight,
                    SteamVR_Actions.vRF_UI,
                    SteamVR_Actions.vRF_PullTrigger,
                    SteamVR_Actions.vRF_Menu,
                    SteamVR_Actions.vRF_D_Up,
                    SteamVR_Actions.vRF_D_Left,
                    SteamVR_Actions.vRF_D_Down,
                    SteamVR_Actions.vRF_D_Right,
                    SteamVR_Actions.vRF_Grab};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[] {
                    SteamVR_Actions.default_Squeeze};
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[0];
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[] {
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand,
                    SteamVR_Actions.vRF_SkeletonLeftHand,
                    SteamVR_Actions.vRF_SkeletonRightHand};
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_Teleport,
                    SteamVR_Actions.default_GrabPinch,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_Squeeze,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_SnapTurnLeft,
                    SteamVR_Actions.default_SnapTurnRight,
                    SteamVR_Actions.vRF_UI,
                    SteamVR_Actions.vRF_PullTrigger,
                    SteamVR_Actions.vRF_Menu,
                    SteamVR_Actions.vRF_D_Up,
                    SteamVR_Actions.vRF_D_Left,
                    SteamVR_Actions.vRF_D_Down,
                    SteamVR_Actions.vRF_D_Right,
                    SteamVR_Actions.vRF_Grab};
        }
        
        private static void PreInitActions()
        {
            SteamVR_Actions.p_default_InteractUI = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/InteractUI")));
            SteamVR_Actions.p_default_Teleport = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/Teleport")));
            SteamVR_Actions.p_default_GrabPinch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/GrabPinch")));
            SteamVR_Actions.p_default_GrabGrip = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/GrabGrip")));
            SteamVR_Actions.p_default_Pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/default/in/Pose")));
            SteamVR_Actions.p_default_SkeletonLeftHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonLeftHand")));
            SteamVR_Actions.p_default_SkeletonRightHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonRightHand")));
            SteamVR_Actions.p_default_Squeeze = ((SteamVR_Action_Single)(SteamVR_Action.Create<SteamVR_Action_Single>("/actions/default/in/Squeeze")));
            SteamVR_Actions.p_default_HeadsetOnHead = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/HeadsetOnHead")));
            SteamVR_Actions.p_default_SnapTurnLeft = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/SnapTurnLeft")));
            SteamVR_Actions.p_default_SnapTurnRight = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/SnapTurnRight")));
            SteamVR_Actions.p_default_Haptic = ((SteamVR_Action_Vibration)(SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/default/out/Haptic")));
            SteamVR_Actions.p_vRF_UI = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/UI")));
            SteamVR_Actions.p_vRF_PullTrigger = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/PullTrigger")));
            SteamVR_Actions.p_vRF_Menu = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/Menu")));
            SteamVR_Actions.p_vRF_D_Up = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/D_Up")));
            SteamVR_Actions.p_vRF_D_Left = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/D_Left")));
            SteamVR_Actions.p_vRF_D_Down = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/D_Down")));
            SteamVR_Actions.p_vRF_D_Right = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/D_Right")));
            SteamVR_Actions.p_vRF_Grab = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/VRF/in/Grab")));
            SteamVR_Actions.p_vRF_SkeletonLeftHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/VRF/in/SkeletonLeftHand")));
            SteamVR_Actions.p_vRF_SkeletonRightHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/VRF/in/SkeletonRightHand")));
            SteamVR_Actions.p_vRF_Pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/VRF/in/Pose")));
            SteamVR_Actions.p_vRF_Haptic = ((SteamVR_Action_Vibration)(SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/VRF/out/Haptic")));
        }
    }
}
