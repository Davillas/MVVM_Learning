﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace WPF_TestApp.Behaviors
{
    class CloseWindow : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += OnButtonClick;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = AssociatedObject;

            var window = FindVisualRoot(button) as Window;
            window?.Close();
        }

        private static DependencyObject FindVisualRoot(DependencyObject obj)
        {
            do
            {
                var parent = VisualTreeHelper.GetParent(obj);
                if (parent is null) return obj;
                obj = parent;

            } while (true);
        }
    }
}