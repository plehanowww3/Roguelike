using ScriptableObjects;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField] private PartsScriptableObject m_partsScriptableObject;
        
    public override void InstallBindings()
    {
        Container.BindInstance(m_partsScriptableObject);
    }
}