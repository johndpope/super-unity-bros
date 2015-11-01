using UnityEngine;

using System.Collections;

namespace LunarCore
{
    public class BaseBehaviour : MonoBehaviour
    {
        #region Life Cycle

        void Awake()
        {
            OnAwake();
        }

        void Start()
        {
            OnStart();
        }

        void OnEnable()
        {
            OnEnabled();
        }

        void OnDisable()
        {
            OnDisabled();
        }

        void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        void FixedUpdate()
        {
            OnFixedUpdate(Time.fixedDeltaTime);
        }

        #endregion

        #region Inheritance

        protected virtual void OnAwake()
        {
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnEnabled()
        {
        }

        protected virtual void OnDisabled()
        {
        }

        protected virtual void OnUpdate(float deltaTime)
        {
        }

        protected virtual void OnFixedUpdate(float deltaTime)
        {
        }

        #endregion

        #region Helpers

        protected T GetRequiredComponent<T>()
        {
            T component = GetComponent<T>();
            assert.IsNotNull(component, "Missing required component: {0}", typeof(T));
            return component;
        }

        #endregion
    }

    public class BaseBehaviour2D : BaseBehaviour
    {
        #region Properties

        public bool flipX
        {
            get { return transform.localScale.x < 0; }
            set
            {
                Vector2 scale = transform.localScale;
                scale.x = value ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }

        public bool flipY
        {
            get { return transform.localScale.y < 0; }
            set
            {
                Vector2 scale = transform.localScale;
                scale.y = value ? -Mathf.Abs(scale.y) : Mathf.Abs(scale.y);
                transform.localScale = scale;
            }
        }

        public Vector2 position2D
        {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }

        public float posX
        {
            get { return transform.localPosition.x; }
            set
            {
                Vector3 position = transform.localPosition;
                position.x = value;
                transform.localPosition = position;
            }
        }

        public float posY
        {
            get { return transform.localPosition.y; }
            set
            {
                Vector3 position = transform.localPosition;
                position.y = value;
                transform.localPosition = position;
            }
        }

        #endregion
    }
}