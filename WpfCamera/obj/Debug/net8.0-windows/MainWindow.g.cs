﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09D7E5334F2B4B8AC101A5F0125239BC7C4D2F49"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfCamera.Controls;


namespace WpfCamera {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CameraImage;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas DrawingCanvas;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCamera.Controls.EdgeDetectionControl EdgeDetectionCustomControl;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FilterComboBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCamera.Controls.GaussianFilterControl GaussianFilterCustomControl;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCamera.Controls.MedianFilterControl MedianFilterCustomControl;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCamera.Controls.BilateralFilterControl BilateralFilterCustomControl;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfCamera.Controls.PixelInfoControl PixelInfo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfCamera;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CameraImage = ((System.Windows.Controls.Image)(target));
            
            #line 15 "..\..\..\MainWindow.xaml"
            this.CameraImage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CameraImage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DrawingCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 16 "..\..\..\MainWindow.xaml"
            this.DrawingCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.CameraImage_MouseMove);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\MainWindow.xaml"
            this.DrawingCanvas.MouseLeave += new System.Windows.Input.MouseEventHandler(this.CameraImage_MouseLeave);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\MainWindow.xaml"
            this.DrawingCanvas.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CameraImage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EdgeDetectionCustomControl = ((WpfCamera.Controls.EdgeDetectionControl)(target));
            return;
            case 4:
            this.FilterComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.FilterComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FilterComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GaussianFilterCustomControl = ((WpfCamera.Controls.GaussianFilterControl)(target));
            return;
            case 6:
            this.MedianFilterCustomControl = ((WpfCamera.Controls.MedianFilterControl)(target));
            return;
            case 7:
            this.BilateralFilterCustomControl = ((WpfCamera.Controls.BilateralFilterControl)(target));
            return;
            case 8:
            this.PixelInfo = ((WpfCamera.Controls.PixelInfoControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
