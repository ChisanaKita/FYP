using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.codeproject.com/Articles/572263/A-Reusable-Base-Class-for-the-Singleton-Pattern-in

/// <summary>
/// Singleton Base Class
/// </summary>
/// <typeparam name="T">Class type</typeparam>

namespace VRF.BaseClass
{
    public abstract class Singleten<T> where T : class
    {
        private static readonly Lazy<T> sInstance = new Lazy<T>(() => CreateInstanceOfT());

        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        public static T Instance { get { return sInstance.Value; } }
    }
}
