using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Utils;

namespace Views.Impl
{
    public class VirtualCameraView : AView
    {
        [field: SerializeField] public List<CameraHolder> Cameras { get; private set; }

        [Serializable]
        public struct CameraHolder
        {
            public ECameraType cameraType;
            public CinemachineVirtualCamera virtualCamera;
        }
    }
}