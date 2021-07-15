using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_Learning.Views.Windows
{
    /// <summary>
    /// Interaction logic for StudentEditorWindow.xaml
    /// </summary>
    public partial class StudentEditorWindow : Window
    {
        #region Name
        public static DependencyProperty NameProperty = DependencyProperty.Register(
            nameof(FirstName),
            typeof(string),
            typeof(StudentEditorWindow),
            new PropertyMetadata(default(string)));

        public string FirstName { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }
        #endregion

        #region LastName : string - Surname


        /// <summary>$summary$</summary>
        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register(
                nameof(LastName),
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));

        /// <summary>$summary$</summary>
        //[Category("")]
        [Description("Surname")]
        public string LastName
        {
            get => (string) GetValue(LastNameProperty);
            set => SetValue(LastNameProperty, value);
        }

        #endregion

        #region Patronymic : string - Patronymic

        /// <summary>$summary$</summary>
        public static readonly DependencyProperty PatronymicProperty =
            DependencyProperty.Register(
                nameof(Patronymic),
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));

        /// <summary>$summary$</summary>
        //[Category("")]
        [Description("Patronymic")]
        public string Patronymic
        {
            get => (string) GetValue(PatronymicProperty);
            set => SetValue(PatronymicProperty, value);
        }

        #endregion

        #region Rating : double - Rating

        /// <summary>$summary$</summary>
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                nameof(Rating),
                typeof(double),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(double)));

        /// <summary>$summary$</summary>
        //[Category("")]
        [Description("Rating")]
        public double Rating
        {
            get => (double) GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        #endregion

        #region BirthDay : DateTime - BirthDay

        /// <summary>$summary$</summary>
        public static readonly DependencyProperty BirthDayProperty =
            DependencyProperty.Register(
                nameof(BirthDay),
                typeof(DateTime),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(DateTime)));

        /// <summary>$summary$</summary>
        //[Category("")]
        [Description("BirthDay")]
        public DateTime BirthDay
        {
            get => (DateTime) GetValue(BirthDayProperty);
            set => SetValue(BirthDayProperty, value);
        }
        #endregion

        public StudentEditorWindow()
        {
            InitializeComponent();
        }

       
    }
}
