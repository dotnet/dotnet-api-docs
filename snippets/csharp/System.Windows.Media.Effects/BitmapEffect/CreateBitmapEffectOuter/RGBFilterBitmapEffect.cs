using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Reflection;

namespace RGBFilter
{
    internal class COMSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal COMSafeHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            Marshal.Release(handle);
            return true;
        }
    }

    public class Ole32Methods
    {
        [DllImport("ole32.dll")]
        internal static extern uint /* HRESULT */ CoCreateInstance(
            ref Guid clsid,
            IntPtr inner,
            uint context,
            ref Guid uuid,
            out COMSafeHandle ppEffect);
    }

    //<SnippetBitmapEffectClass>
    public class RGBFilterBitmapEffect : BitmapEffect
    {

        #region Public Methods

        public RGBFilterBitmapEffect()
        {
        }

        public new RGBFilterBitmapEffect Clone()
        {
            return (RGBFilterBitmapEffect)base.Clone();
        }

        public new RGBFilterBitmapEffect CloneCurrentValue()
        {
            return (RGBFilterBitmapEffect)base.CloneCurrentValue();
        }

        #endregion Public Methods

        #region Public Properties
        public double Red
        {
            get
            {
                return (double)GetValue(RedProperty);
            }
            set
            {
                SetValue(RedProperty, value);
            }
        }

        public double Green
        {
            get
            {
                return (double)GetValue(GreenProperty);
            }
            set
            {
                SetValue(GreenProperty, value);
            }
        }

        public double Blue
        {
            get
            {
                return (double)GetValue(BlueProperty);
            }
            set
            {
                SetValue(BlueProperty, value);
            }
        }

        public static readonly DependencyProperty RedProperty = DependencyProperty.Register(
            "Red",
            typeof(double),
            typeof(RGBFilterBitmapEffect),
            new PropertyMetadata(defaultRed, OnPropertyInvalidated));

        public static readonly DependencyProperty GreenProperty = DependencyProperty.Register(
            "Green",
            typeof(double),
            typeof(RGBFilterBitmapEffect),
            new PropertyMetadata(defaultGreen, OnPropertyInvalidated));

        public static readonly DependencyProperty BlueProperty = DependencyProperty.Register(
            "Blue",
            typeof(double),
            typeof(RGBFilterBitmapEffect),
            new PropertyMetadata(defaultBlue, OnPropertyInvalidated));

        #endregion Public Properties

        #region Protected Methods

        protected override void UpdateUnmanagedPropertyState(SafeHandle unmanagedEffect)
        {
            BitmapEffect.SetValue(unmanagedEffect, "Red", this.Red);
            BitmapEffect.SetValue(unmanagedEffect, "Green", this.Green);
            BitmapEffect.SetValue(unmanagedEffect, "Blue", this.Blue);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new RGBFilterBitmapEffect();
        }

        protected override void CloneCore(Freezable sourceFreezable)
        {
            RGBFilterBitmapEffect cycle =
                (RGBFilterBitmapEffect)sourceFreezable;

            base.CloneCore(sourceFreezable);
            Red = defaultRed;
            Green = defaultGreen;
            Blue = defaultBlue;
        }
        protected override void GetCurrentValueAsFrozenCore(Freezable sourceFreezable)
        {
            RGBFilterBitmapEffect cycle = (RGBFilterBitmapEffect)sourceFreezable;

            base.GetCurrentValueAsFrozenCore(sourceFreezable);

            Red = defaultRed;
            Green = defaultGreen;
            Blue = defaultBlue;
        }

        protected override void CloneCurrentValueCore(Freezable sourceAnimatable)
        {
            RGBFilterBitmapEffect sourceRGBFilterBitmapEffect = (RGBFilterBitmapEffect)sourceAnimatable;

            sourceRGBFilterBitmapEffect = this;

            base.CloneCurrentValueCore(sourceAnimatable);

            Red = sourceRGBFilterBitmapEffect.Red;
            Green = sourceRGBFilterBitmapEffect.Green;
            Blue = sourceRGBFilterBitmapEffect.Blue;
        }
        #endregion ProtectedMethods

        private static void OnPropertyInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (((double)e.NewValue) > 1.0 || ((double)e.NewValue) < -1.0)
                throw new ArgumentOutOfRangeException("Red", "Property value must be between -1 and 1.");
            else
                ((RGBFilterBitmapEffect)d).OnChanged();
        }

        #region Internal Fields
        internal const double defaultRed = 0x0;
        internal const double defaultGreen = 0x0;
        internal const double defaultBlue = 0x0;
        #endregion Internal Fields
    }
    //</SnippetBitmapEffectClass>
}
