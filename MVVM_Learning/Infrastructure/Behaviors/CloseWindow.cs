﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace MVVM_Learning.Infrastructure.Behaviors
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
        private void OnButtonClick(object sender, RoutedEventArgs e) => (AssociatedObject.FindVisualRoot() as Window)?.Close();
    }
}
