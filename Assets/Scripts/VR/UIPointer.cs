using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

namespace VRF
{
    public class UIPointer : BaseInputModule
    {
        public float DefaultLength = 0.5f;
        public GameObject Dot;
        private LineRenderer _LineRenderer = null;
        public SteamVR_Input_Sources CurrentHandInput = SteamVR_Input_Sources.LeftHand;

        private GameObject _CurrentGameObject = null;
        private PointerEventData _Data = null;
        private Camera Camera;

        protected override void Awake()
        {
            base.Awake();
            _Data = new PointerEventData(eventSystem);

            _LineRenderer = GetComponent<LineRenderer>();

            Camera = GetComponent<Camera>();
        }
        #region Input
        public override void Process()
        {
            _Data.Reset();
            _Data.position = new Vector2(Camera.pixelWidth / 2, Camera.pixelHeight / 2);

            eventSystem.RaycastAll(_Data, m_RaycastResultCache);

            _Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
            _CurrentGameObject = _Data.pointerCurrentRaycast.gameObject;

            m_RaycastResultCache.Clear();

            HandlePointerExitAndEnter(_Data, _CurrentGameObject);

            if (SteamVR_Actions.VRF.UI.GetStateDown(CurrentHandInput))
            {
                ProcessPress(_Data);
            }

            if (SteamVR_Actions.VRF.UI.GetStateUp(CurrentHandInput))
            {
                ProcessRelease(_Data);
            }
        }

        public PointerEventData GetData()
        {
            return _Data;
        }

        private void ProcessPress(PointerEventData data)
        {
            data.pointerPressRaycast = data.pointerCurrentRaycast;

            GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(_CurrentGameObject, data, ExecuteEvents.pointerDownHandler);

            if (newPointerPress == null)
            {
                newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(_CurrentGameObject);
            }

            data.pressPosition = _Data.position;
            data.pointerPress = newPointerPress;
            data.rawPointerPress = _CurrentGameObject;
        }

        private void ProcessRelease(PointerEventData data)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

            GameObject PointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(_CurrentGameObject);

            if (data.pointerPress == PointerUpHandler)
            {
                ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
            }

            eventSystem.SetSelectedGameObject(null);

            data.pressPosition = Vector2.zero;
            data.pointerPress = null;
            data.rawPointerPress = null;
        }
        #endregion
        #region Graphic
        void Update()
        {
            UpdateLine();
        }

        void UpdateLine()
        {
            float _TargetLength = GetData().pointerCurrentRaycast.distance == 0 ? DefaultLength : GetData().pointerCurrentRaycast.distance;
            RaycastHit hit = CreateRaycast(_TargetLength);
            Vector3 _EndPosition = transform.position + (transform.forward * _TargetLength);
            if (hit.collider != null)
            {
                _EndPosition = hit.point;
            }
            Dot.transform.position = _EndPosition;

            _LineRenderer.SetPosition(0, transform.position);
            _LineRenderer.SetPosition(1, _EndPosition);
        }

        RaycastHit CreateRaycast(float length)
        {
            RaycastHit hit;

            Ray ray = new Ray(transform.position, transform.forward);

            Physics.Raycast(ray, out hit, DefaultLength);

            return hit;
        }
        #endregion
    }
}
