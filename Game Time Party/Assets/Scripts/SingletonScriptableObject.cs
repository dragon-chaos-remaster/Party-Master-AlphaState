using UnityEngine;
using System.Linq;
public  abstract class SingletonScriptableObject<Tea> : ScriptableObject where Tea : ScriptableObject
{
    static Tea instance = null;
    public static Tea Instance
    {
        get
        {
            if(instance == null)
            {
                Tea[] results = Resources.FindObjectsOfTypeAll<Tea>();
                if(results.Length == 0)
                {
                    Debug.LogError("Singleton error -> Instance -> results lenght is 0 for type " + typeof(Tea).ToString() + ".");
                    return null;
                }
                if(results.Length > 1)
                {
                    Debug.LogError("Singleton error -> Instance -> results lenght is greater than 1 for type " + typeof(Tea).ToString() + ".");
                    return null;
                }
                instance = results[0];
            }
            return instance;
        }
    }
}
