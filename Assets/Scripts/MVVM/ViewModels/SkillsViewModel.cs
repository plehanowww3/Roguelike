using UniRx;
using UnityEngine;

namespace MVVM.ViewModels
{
    public class SkillsViewModel: ViewModel
    {
        internal ReactiveCommand m_exampleCommand;
        
        internal SkillsViewModel(Model _model): base(_model)
        {
            Debug.Log("Constrictor ExampleViewModel");
            m_exampleCommand = new ReactiveCommand();
            m_exampleCommand.Subscribe(_ => LogText());
        }

        private void LogText()
        {
            Debug.Log($"This is text from {this}");
        }
        
    }
}