﻿#pragma checksum "..\..\..\Controls\ContentEditWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "777307C6420C29B22A5868255280BF826EE1ED7AECD4766010C57307711256A5"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PCLinkerProject.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace PCLinkerProject.Controls {
    
    
    /// <summary>
    /// ContentEditWindow
    /// </summary>
    public partial class ContentEditWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\Controls\ContentEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IconTextbox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Controls\ContentEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleTextbox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Controls\ContentEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ShellTextbox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Controls\ContentEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CommandTextbox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PCLinkerProject;component/controls/contenteditwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\ContentEditWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\Controls\ContentEditWindow.xaml"
            ((System.Windows.Controls.ProgressBar)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ProgressBar_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IconTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 43 "..\..\..\Controls\ContentEditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IconSelectButton_onClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ShellTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 67 "..\..\..\Controls\ContentEditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShellPathSelectButton_onClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CommandTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 87 "..\..\..\Controls\ContentEditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AcceptButton_onClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 93 "..\..\..\Controls\ContentEditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_onClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

