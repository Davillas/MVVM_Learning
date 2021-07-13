using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace MVVM_Learning.Infrastructure.Behaviors
{

    class WindowTitleBarBehavior : Behavior<UIElement>
    {
        private Window _Window;

        protected override void OnAttached()
        {
            _Window = AssociatedObject as Window ?? AssociatedObject.FindLogicalParent<Window>();
            AssociatedObject.MouseLeftButtonDown += OnMouseDown;

        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnMouseDown;
            _Window = null;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount > 1) return;
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;
            window.DragMove();
        }
    }
}
