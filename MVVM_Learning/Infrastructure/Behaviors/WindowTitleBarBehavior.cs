using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace MVVM_Learning.Infrastructure.Behaviors
{

    class WindowTitleBarBehavior : Behavior<UIElement>
    {
        private Window _Window;

        protected override void OnAttached()
        {
            _Window = AssociatedObject as Window ?? AssociatedObject.Find;
        }

        protected override void OnDetaching()
        {
            
        }
    }
}
