﻿#pragma checksum "..\..\..\MenuProducts.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B772AC6E83D5B2150B9413B8A25C34F44E521EDE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using _0auth_client;


namespace _0auth_client {
    
    
    /// <summary>
    /// MenuProducts
    /// </summary>
    public partial class MenuProducts : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\MenuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame contentFR;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MenuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock countTB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MenuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button profileBT;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MenuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sorCB;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MenuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filCB;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MenuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTB;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\MenuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productsLV;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/0auth_client;component/menuproducts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MenuProducts.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.contentFR = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.countTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.profileBT = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\MenuProducts.xaml"
            this.profileBT.Click += new System.Windows.RoutedEventHandler(this.profileBT_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sorCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\MenuProducts.xaml"
            this.sorCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.sorCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.filCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\MenuProducts.xaml"
            this.filCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.filCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.searchTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\..\MenuProducts.xaml"
            this.searchTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.productsLV = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

