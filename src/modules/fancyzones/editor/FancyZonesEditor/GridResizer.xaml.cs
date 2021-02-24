﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using FancyZonesEditor.Models;

namespace FancyZonesEditor
{
    /// <summary>
    /// Interaction logic for GridResizer.xaml
    /// </summary>
    public partial class GridResizer : Thumb
    {
        public int StartRow { get; set; }

        public int EndRow { get; set; }

        public int StartCol { get; set; }

        public int EndCol { get; set; }

        public LayoutModel Model { get; set; }

        private Orientation _orientation;

        public GridResizer()
        {
            InitializeComponent();
        }

        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }

            set
            {
                _orientation = value;
                ApplyTemplate();
                Border body = (Border)Template.FindName("Body", this);
                if (value == Orientation.Vertical)
                {
                    body.RenderTransform = new TranslateTransform(0, -24);
                    body.Cursor = Cursors.SizeWE;
                }
                else
                {
                    TransformGroup group = new TransformGroup();
                    group.Children.Add(new RotateTransform(90, 24, 24));
                    group.Children.Add(new TranslateTransform(-24, 0));

                    body.RenderTransform = group;
                    body.Cursor = Cursors.SizeNS;
                }
            }
        }
    }
}
