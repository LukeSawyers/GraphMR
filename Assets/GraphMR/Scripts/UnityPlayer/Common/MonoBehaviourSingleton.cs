using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace diagramMR
{
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// The instance of this singleton
        /// </summary>
        public static T Instance
        {
            get;
            private set;
        }

        private int Destroying = 0;

        protected virtual void Awake()
        {
            if(Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Destroying++;
                Destroy(this);
            }
        }
    }
}
