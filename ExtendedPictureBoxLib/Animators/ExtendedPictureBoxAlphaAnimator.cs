﻿using System;
using System.ComponentModel;

using Animations;

namespace ExtendedPictureBoxLib.Animators
{
    /// <summary>
    /// Class inheriting <see cref="Animations.AnimatorBase"/> to animate the <see
    /// cref="ExtendedPictureBoxLib.ExtendedPictureBox.Alpha"/> of a <see cref="ExtendedPictureBox"/>.
    /// </summary>
    public partial class ExtendedPictureBoxAlphaAnimator : AnimatorBase
    {
        #region Fields

        private const byte DEFAULT_ALPHA = 255;

        private ExtendedPictureBox _extendedPictureBox;
        private byte _startAlpha;
        private byte _endAlpha;

        #endregion

        #region (* Constructors *)

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public ExtendedPictureBoxAlphaAnimator()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="container">Container the new instance should be added to.</param>

        public ExtendedPictureBoxAlphaAnimator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _startAlpha = DEFAULT_ALPHA;
            _endAlpha = DEFAULT_ALPHA;
        }

        #endregion

        #region (* Public interface *)

        /// <summary>
        /// Gets or sets the starting alpha for the animation.
        /// </summary>
        [Category("Appearance"), DefaultValue(DEFAULT_ALPHA)]
        [Browsable(true)]
        [Description("Gets or sets the starting alpha for the animation.")]
        public byte StartAlpha
        {
            get { return _startAlpha; }
            set
            {
                if (_startAlpha == value)
                    return;

                _startAlpha = value;

                OnStartValueChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the ending alpha for the animation.
        /// </summary>
        [Category("Appearance"), DefaultValue(DEFAULT_ALPHA)]
        [Browsable(true)]
        [Description("Gets or sets the ending alpha for the animation.")]
        public byte EndAlpha
        {
            get { return _endAlpha; }
            set
            {
                if (_endAlpha == value)
                    return;

                _endAlpha = value;

                OnEndValueChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ExtendedPictureBox"/> which <see
        /// cref="ExtendedPictureBoxLib.ExtendedPictureBox.Alpha"/> should be animated.
        /// </summary>
        [Browsable(true), DefaultValue(null), Category("Behavior")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Gets or sets which ExtendedPictureBox should be animated.")]
        public ExtendedPictureBox ExtendedPictureBox
        {
            get { return _extendedPictureBox; }
            set
            {
                if (_extendedPictureBox == value)
                    return;

                if (_extendedPictureBox != null)
                    _extendedPictureBox.AlphaChanged -= new EventHandler(OnCurrentValueChanged);

                _extendedPictureBox = value;

                if (_extendedPictureBox != null)
                    _extendedPictureBox.AlphaChanged += new EventHandler(OnCurrentValueChanged);

                base.ResetValues();
            }
        }

        #endregion

        #region Overridden from AnimatorBase

        /// <summary>
        /// Gets or sets the currently shown value.
        /// </summary>
        protected override object CurrentValueInternal
        {
            get { return _extendedPictureBox == null ? (byte)0 : _extendedPictureBox.Alpha; }
            set
            {
                if (_extendedPictureBox != null)
                    _extendedPictureBox.Alpha = (byte)value;
            }
        }

        /// <summary>
        /// Gets or sets the starting value for the animation.
        /// </summary>
        public override object StartValue
        {
            get { return StartAlpha; }
            set { StartAlpha = (byte)value; }
        }

        /// <summary>
        /// Gets or sets the ending value for the animation.
        /// </summary>
        public override object EndValue
        {
            get { return EndAlpha; }
            set { EndAlpha = (byte)value; }
        }

        /// <summary>
        /// Calculates an interpolated value between <see cref="StartValue"/> and <see
        /// cref="EndValue"/> for a given step in %. Giving 0 will return the <see
        /// cref="StartValue"/>. Giving 100 will return the <see cref="EndValue"/>.
        /// </summary>
        /// <param name="step">Animation step in %</param>
        /// <returns>Interpolated value for the given step.</returns>
        protected override object GetValueForStep(double step)
        {
            byte result = (byte)InterpolateIntegerValues(_startAlpha, _endAlpha, step);
            return (byte)InterpolateIntegerValues(_startAlpha, _endAlpha, step);
        }

        #endregion
    }
}