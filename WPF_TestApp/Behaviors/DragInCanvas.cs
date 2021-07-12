using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Xaml.Behaviors;

namespace WPF_TestApp.Behaviors
{
    public class DragInCanvas : Behavior<UIElement>
    {
        private Point _StartPoint;
        private Canvas _Canvas;
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += OnLeftButtonDown;
        }

        
        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnLeftButtonDown;
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;
        }
        private void OnLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if((_Canvas ??= VisualTreeHelper.GetParent(AssociatedObject) as Canvas) is null)
                return;
            _StartPoint = e.GetPosition(AssociatedObject);
            AssociatedObject.CaptureMouse();
            AssociatedObject.MouseMove += OnMouseMove;
            AssociatedObject.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseUp -= OnMouseUp;
            AssociatedObject.ReleaseMouseCapture();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            
            var obj = AssociatedObject;
            var current_pos = e.GetPosition(_Canvas);

            var delta = current_pos - _StartPoint;

            obj.SetValue(Canvas.LeftProperty, delta.X);
            obj.SetValue(Canvas.TopProperty, delta.Y);
        }
    }
}
