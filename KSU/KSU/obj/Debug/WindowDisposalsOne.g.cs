﻿#pragma checksum "..\..\WindowDisposalsOne.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "527BBC689F1181438CA3B252B0DD0EC81D47277946588D44191DD9242AE5E3A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KSU;
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


namespace KSU {
    
    
    /// <summary>
    /// WindowDisposalsOne
    /// </summary>
    public partial class WindowDisposalsOne : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDate;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNumber;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTotalNumber;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCost;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbContent;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbViews;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbReason;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPlace;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\WindowDisposalsOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/KSU;component/windowdisposalsone.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowDisposalsOne.xaml"
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
            this.dpDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.tbNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbTotalNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\WindowDisposalsOne.xaml"
            this.tbTotalNumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbTotalNumber_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbCost = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.lbContent = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.lbViews = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.lbReason = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.cbPlace = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\WindowDisposalsOne.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\WindowDisposalsOne.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

