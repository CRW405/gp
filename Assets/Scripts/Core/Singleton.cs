using UnityEngine;

// generic class of generic type T, T is a Component type which is made for reusable objects
public class Singleton<T> : MonoBehaviour where T : Component {
  private static T _instance; // this istance

  // Public accessor for our private instance
  public static T Instance {
    get {
      // if nothing exists when we get our instance, find it
      if (_instance == null) {
        _instance = FindObjectOfType<T>();
        
        // if we cant find it, create it
        if (_instance == null) {
          GameObject obj = new GameObject();
          obj.name = typeof(T).Name;
          _instance = obj.AddComponent<T>();
        }
      }
      // finally, get
      return _instance;
    }
  }
  
  // Awake ensures all dependencies are loaded before the scene begins
  // virtual means children can extend or override this (enfored), 
  // allows for base logic to run before custom child logic
  public virtual void Awake() {
    if (_instance == null) {
      //ensure instance persists across scenes
      _instance = this as T;
      DontDestroyOnLoad(gameObject);
    } else {
      // if there is an object already there due to an error,
      // destroy it to prevent duplication
      Destroy(gameObject);
    }
  }
}

/*
 *

                    using UnityEngine;

                    public class Singleton<T> : MonoBehaviour where T : Component
                    {
                        private static T _instance;

                        public static T Instance
                        {
                            get
                            {
                                if (_instance == null)
                                {
                                    _instance = FindObjectOfType<T>();
                                    if (_instance == null)
                                    {
                                        GameObject obj = new GameObject();
                                        obj.name = typeof(T).Name;
                                        _instance = obj.AddComponent<T>();
                                    }
                                }
                                return _instance;
                            }
                        }

                        public virtual void Awake()
                        {
                            if (_instance == null)
                            {
                                _instance = this as T;
                                DontDestroyOnLoad(gameObject);
                            }
                            else { Destroy(gameObject); }
                        }
                    }
                */
