using UnityEngine;
using Zenject;

namespace MVVM.ViewModels
{
    public abstract class ViewModel
    {
        /// <summary>
        /// Ссылка на модель
        /// </summary>
        [Inject]
        protected Model model { get; }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        /// <param name="_model">объект модели</param>
        protected ViewModel(Model _model)
        {
            model = _model;
            Debug.Log($"{this.GetType()} injected");
        }
    }
}