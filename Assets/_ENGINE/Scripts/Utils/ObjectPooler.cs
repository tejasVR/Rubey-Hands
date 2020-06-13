using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XREngine
{
    public abstract class ObjectPooler : MonoBehaviour
    {
        [Header("Object Pooling Properties")]
        [SerializeField] protected GameObject objectPrefab;
        [SerializeField] protected Transform objectHolder;
        [SerializeField] protected int startSize = 20;

        protected Stack<GameObject> pool;

        protected Stack<GameObject> queuedForDestroy;

        private bool initialized = false;

        protected virtual void Awake()
        {
            pool = new Stack<GameObject>(startSize);
            queuedForDestroy = new Stack<GameObject>();

            objectHolder = (objectHolder ? objectHolder : transform);

            InitializePoolObjects();
        }

        void InitializePoolObjects()
        {
            if (initialized) return;
            initialized = true;

            for (int i = 0; i < startSize; i++)
            {
                AddObjectToPool();
            }
        }

        protected Stack<GameObject> GetPooledObjects()
        {
            return pool;
        }
      
        protected void AddObjectToPool()
        {
            GameObject obj = Instantiate(objectPrefab, objectHolder);
            obj.SetActive(false);
            pool.Push(obj);
        }

        protected GameObject GetFromPool()
        {
            if (pool.Count == 0)
            {
                AddObjectToPool();
            }

            return pool.Pop();
        }

        protected void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            pool.Push(obj);
        }

        protected void ReturnAllToPool()
        {
            foreach (Transform obj in objectHolder)
            {
                ReturnToPool(obj.gameObject);
            }
        }

        void LateUpdate()
        {
            //while (queuedForDestroy.Count > 0)
            //{
            //    ReturnToPool(queuedForDestroy.Pop());
            //}
        }
    }
}