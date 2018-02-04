using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;

[assembly: CLSCompliant(true)]

namespace System.Windows.Forms
{
  /// <summary>
  /// Represents a component to pick an angle.
  /// </summary>
  [DefaultProperty("Value")]
  [DefaultEvent("ValueChanged")]
  [ToolboxBitmap(typeof(CircleAnglePicker), "CircleAnglePickerIcon.bmp")]
  public partial class CircleAnglePicker : UserControl
  {
    /// <summary>
    /// Defines the circleBackColor.
    /// </summary>
    private Color circleBackColor = Color.Transparent;

    /// <summary>
    /// Defines the circleColor.
    /// </summary>
    private Color circleColor = SystemColors.ControlText;

    /// <summary>
    /// Defines the circleWidth.
    /// </summary>
    private int circleWidth = 2;

    /// <summary>
    /// Defines the coreColor.
    /// </summary>
    private Color coreColor = SystemColors.ControlText;

    /// <summary>
    /// Defines the coreType.
    /// </summary>
    private CoreType coreType = CoreType.Rectangle;

    /// <summary>
    /// Defines the coreWidth.
    /// </summary>
    private int coreWidth = 4;

    /// <summary>
    /// Defines the currentValue.
    /// </summary>
    private int currentValue = 0;

    /// <summary>
    /// Defines the innerCircle.
    /// </summary>
    private bool innerCircle = false;

    /// <summary>
    /// Defines the innerCircleColor.
    /// </summary>
    private Color innerCircleColor = SystemColors.ControlText;

    /// <summary>
    /// Defines the innerCircleOffset.
    /// </summary>
    private int innerCircleOffset = 2;

    /// <summary>
    /// Defines the innerCircleStyle
    /// </summary>
    private DashStyle innerCircleStyle = DashStyle.Dot;

    /// <summary>
    /// Defines the innerCircleWidth
    /// </summary>
    private int innerCircleWidth = 2;

    /// <summary>
    /// Defines the lineCap
    /// </summary>
    private LineCap lineCap = LineCap.NoAnchor;

    /// <summary>
    /// Defines the lineColor
    /// </summary>
    private Color lineColor = SystemColors.ControlText;

    /// <summary>
    /// Defines the lineCut
    /// </summary>
    private int lineCut = 0;

    /// <summary>
    /// Defines the lineStyle
    /// </summary>
    private DashStyle lineStyle = DashStyle.Solid;

    /// <summary>
    /// Defines the lineWidth
    /// </summary>
    private int lineWidth = 1;

    /// <summary>
    /// Defines the shading
    /// </summary>
    private bool shading = false;

    /// <summary>
    /// Defines the shadingOpacity.
    /// </summary>
    private double shadingOpacity = 0.75;

    /// <summary>
    /// Defines the shadingScale.
    /// </summary>
    private double shadingScale = 0.6;

    /// <summary>
    /// Initializes a new instance of the <see cref="CircleAnglePicker"/> class.
    /// </summary>
    public CircleAnglePicker()
    {
      InitializeComponent();

      MouseWheel += CircleAnglePicker_MouseWheel;
    }

    /// <summary>
    /// Specifies the value change handler.
    /// </summary>
    public event EventHandler ValueChanged;

    /// <summary>
    /// Gets or sets a value indicating whether AutoScroll.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool AutoScroll { get; set; }

    /// <summary>
    /// Gets or sets the AutoScrollMargin.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Size AutoScrollMargin { get; set; }

    /// <summary>
    /// Gets or sets the AutoScrollMinSize.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Size AutoScrollMinSize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether AutoSize.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool AutoSize { get; set; }

    /// <summary>
    /// Gets or sets the AutoSizeMode.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Reviewed.")]
    public new AutoSizeMode AutoSizeMode { get; set; }

    /// <summary>
    /// Gets or sets background color of the circle.
    /// </summary>
    [Category("Circle")]
    [Description("The background color of the circle.")]
    [DefaultValue(typeof(Color), "Transparent")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public Color CircleBackColor
    {
      get
      {
        return circleBackColor;
      }
      set
      {
        circleBackColor = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets contour color of the circle.
    /// </summary>
    [Category("Circle")]
    [Description("The contour color of the circle.")]
    [DefaultValue(typeof(Color), "ControlText")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public Color CircleColor
    {
      get
      {
        return circleColor;
      }
      set
      {
        circleColor = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets contour width of the circle.
    /// </summary>
    [Category("Circle")]
    [Description("The contour width of the circle.")]
    [DefaultValue(2)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public int CircleWidth
    {
      get
      {
        return circleWidth;
      }
      set
      {
        if (value <= 0)
        {
          value = 1;
        }

        circleWidth = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets color of the core.
    /// </summary>
    [Category("Core")]
    [Description("The color of the core.")]
    [DefaultValue(typeof(Color), "ControlText")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public Color CoreColor
    {
      get
      {
        return coreColor;
      }
      set
      {
        if (value == Color.Transparent)
        {
          throw new ArgumentException("Transparent color is not supported.");
        }

        coreColor = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets type of the core.
    /// </summary>
    [Category("Core")]
    [Description("Type of the core.")]
    [DefaultValue(typeof(CoreType), "Rectangle")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public CoreType CoreType
    {
      get
      {
        return coreType;
      }
      set
      {
        coreType = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the size of core.
    /// </summary>
    [Category("Core")]
    [Description("The core size.")]
    [DefaultValue(4)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public int CoreWidth
    {
      get
      {
        return coreWidth;
      }
      set
      {
        if (value <= 0)
        {
          value = 1;
        }

        coreWidth = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the Font.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Font Font { get; set; }

    /// <summary>
    /// Gets or sets the ForeColor.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Color ForeColor { get; set; }

    /// <summary>
    /// Gets or sets the ImeMode.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public new ImeMode ImeMode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the inner circle should be displayed or not.
    /// </summary>
    [Category("Inner Circle")]
    [Description("Specifies whether to display an additional circle inside of the main circle.")]
    [DefaultValue(false)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public bool InnerCircle
    {
      get
      {
        return innerCircle;
      }
      set
      {
        innerCircle = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the color of the inner circle.
    /// </summary>
    [Category("Inner Circle")]
    [Description("The color of the inner circle.")]
    [DefaultValue(typeof(Color), "ControlText")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public Color InnerCircleColor
    {
      get
      {
        return innerCircleColor;
      }
      set
      {
        if (value == Color.Transparent)
        {
          throw new ArgumentException("Transparent color is not supported.");
        }

        innerCircleColor = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets an offset from the contour of the main circle.
    /// </summary>
    [Category("Inner Circle")]
    [Description("Specifies an offset from the contour of the main circle.")]
    [DefaultValue(2)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public int InnerCircleOffset
    {
      get
      {
        return innerCircleOffset;
      }
      set
      {
        if (value < 0)
        {
          value = 0;
        }

        innerCircleOffset = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets dash-style of the inner circle contour.
    /// </summary>
    [Category("Inner Circle")]
    [Description("The style of the inner circle contour.")]
    [DefaultValue(typeof(DashStyle), "Dot")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public DashStyle InnerCircleStyle
    {
      get
      {
        return innerCircleStyle;
      }
      set
      {
        if (value == DashStyle.Custom)
        {
          throw new ArgumentException("Custom style is not supported.");
        }

        innerCircleStyle = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the thickness of the inner circle.
    /// </summary>
    [Category("Inner Circle")]
    [Description("The thickness of the inner circle.")]
    [DefaultValue(2)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public int InnerCircleWidth
    {
      get
      {
        return innerCircleWidth;
      }
      set
      {
        if (value <= 0)
        {
          value = 1;
        }

        innerCircleWidth = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the cap style of the line.
    /// </summary>
    [Category("Line")]
    [Description("The cap style of the line.")]
    [DefaultValue(typeof(LineCap), "NoAnchor")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public LineCap LineCap
    {
      get
      {
        return lineCap;
      }
      set
      {
        if (value == LineCap.Custom)
        {
          throw new ArgumentException("Custom cap is not supported.");
        }

        lineCap = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the color of the line.
    /// </summary>
    [Category("Line")]
    [Description("The color of the line.")]
    [DefaultValue(typeof(Color), "ControlText")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public Color LineColor
    {
      get
      {
        return lineColor;
      }
      set
      {
        if (value == Color.Transparent)
        {
          throw new ArgumentException("Transparent color is not supported.");
        }

        lineColor = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the size to which the line length should be reduced.
    /// </summary>
    [Category("Line")]
    [Description("Allows to reduce the length of the line. This can be useful when using LineCap.")]
    [DefaultValue(0)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public int LineCut
    {
      get
      {
        return lineCut;
      }
      set
      {
        if (value < 0)
        {
          value = 0;
        }

        lineCut = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the dash-style of the line.
    /// </summary>
    [Category("Line")]
    [Description("The style of the line.")]
    [DefaultValue(typeof(DashStyle), "Solid")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public DashStyle LineStyle
    {
      get
      {
        return lineStyle;
      }
      set
      {
        if (value == DashStyle.Custom)
        {
          throw new ArgumentException("Custom style is not supported.");
        }

        lineStyle = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the line thickness.
    /// </summary>
    [Category("Line")]
    [Description("The line thickness.")]
    [DefaultValue(1)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public int LineWidth
    {
      get
      {
        return lineWidth;
      }
      set
      {
        if (value <= 0)
        {
          value = 1;
        }

        lineWidth = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to display a shading circle or not.
    /// </summary>
    [Category("Shading")]
    [Description("Specifies whether to display shading of the circle.")]
    [DefaultValue(false)]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public bool Shading
    {
      get
      {
        return shading;
      }
      set
      {
        shading = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the transparency level of the shading.
    /// </summary>
    [DefaultValue(0.75)]
    [Category("Shading")]
    [Description("The transparency level of the shading.")]
    [TypeConverter(typeof(OpacityConverter))]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public double ShadingOpacity
    {
      get
      {
        return shadingOpacity;
      }
      set
      {
        shadingOpacity = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the size of the shading.
    /// </summary>
    [DefaultValue(0.6)]
    [Category("Shading")]
    [Description("The size of the shading.")]
    [TypeConverter(typeof(OpacityConverter))]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public double ShadingScale
    {
      get
      {
        return shadingScale;
      }
      set
      {
        shadingScale = value;

        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the size of this control is in pixels.
    /// </summary>
    [Category("Layout")]
    [Description("The size of this control is in pixels.")]
    [DefaultValue(typeof(Size), "32,32")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public new Size Size
    {
      get
      {
        return base.Size;
      }
      set
      {
        base.Size = value;
      }
    }

    /// <summary>
    /// Gets or sets the value indicating the angle.
    /// </summary>
    [DefaultValue(0)]
    [Category("Behavior")]
    [Description("The value indicating the angle.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1516:ElementsMustBeSeparatedByBlankLine", Justification = "Reviewed.")]
    public int Value
    {
      get
      {
        return currentValue;
      }
      set
      {
        if (value > 180)
        {
          value = -180;
        }
        else if (value < -180)
        {
          value = 180;
        }

        int oldValue = currentValue;

        currentValue = value;

        Refresh();

        if (currentValue != oldValue)
        {
          ValueChanged?.Invoke(this, null);
        }
      }
    }

    /// <summary>
    /// Processes a command key.
    /// </summary>
    /// <param name="msg">A <see cref="Message"/>, passed by reference, that represents the window message to process.</param>
    /// <param name="keyData">One of the <see cref="Keys"/> values that represents the key to process.</param>
    /// <returns><c>true</c> if the character was processed by the control; otherwise, <c>false</c>.</returns>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Right || keyData == Keys.Left || keyData == Keys.Up || keyData == Keys.Down)
      {
        CircleAnglePicker_KeyDown(this, new KeyEventArgs(keyData));
        return true;
      }
      else
      {
        return base.ProcessCmdKey(ref msg, keyData);
      }
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    private void CircleAnglePicker_KeyDown(object sender, KeyEventArgs e)
    {
      int value = Value;
      int d = e.Control ? -1 : 1;
      int k = e.Shift ? 5 : 0;

      if ((int)e.KeyCode >= 49 && (int)e.KeyCode <= 58)
      {
        value = value - ((((10 - (58 - (int)e.KeyCode)) * 10) - k) * d);
      }
      else if (e.KeyCode == Keys.D0)
      {
        value = 0;
      }
      else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
      {
        value += 10 - k;
      }
      else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
      {
        value -= 10 + k;
      }

      SetValue(value);
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    private void CircleAnglePicker_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        SetAngle(e.Location);
      }
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    private void CircleAnglePicker_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        SetAngle(e.Location);
      }
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    private void CircleAnglePicker_MouseWheel(object sender, MouseEventArgs e)
    {
      int value = Value;

      if (e.Delta > 0)
      {
        value += 10;
      }
      else
      {
        value -= 10;
      }

      SetValue(value);
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    private void CircleAnglePicker_PaddingChanged(object sender, EventArgs e)
    {
      Refresh();
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    private void CircleAnglePicker_Paint(object sender, PaintEventArgs e)
    {
      var g = e.Graphics;

      g.PageUnit = GraphicsUnit.Pixel;
      g.SmoothingMode = SmoothingMode.AntiAlias;

      int offset = CircleWidth / 2;
      var crect = new Rectangle
      (
        ClientRectangle.X + Padding.Left + offset,
        ClientRectangle.Y + Padding.Top + offset,
        ClientRectangle.Width - Padding.Size.Width - CircleWidth - offset,
        ClientRectangle.Height - Padding.Size.Height - CircleWidth - offset
      );

      DrawCircle(g, crect);
      DrawLine(g, crect);
      DrawPoint(g, crect);
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    private void CircleAnglePicker_Resize(object sender, EventArgs e)
    {
      Refresh();
    }

    /// <summary>
    /// Draws circle.
    /// </summary>
    /// <param name="g">The <see cref="Graphics"/> instance.</param>
    /// <param name="rect">The <see cref="Rectangle"/> of the circle.</param>
    private void DrawCircle(Graphics g, Rectangle rect)
    {
      // background
      if (CircleBackColor != Color.Transparent)
      {
        using (var b = new SolidBrush(CircleBackColor))
        {
          g.FillEllipse(b, rect);
        }
      }

      // shading
      if (Shading)
      {
        using (var path = new GraphicsPath())
        {
          path.AddEllipse(rect);

          using (var gradiend = new PathGradientBrush(path))
          {
            gradiend.FocusScales = new PointF(1.0f - (float)ShadingScale, 1.0f - (float)ShadingScale);
            gradiend.CenterColor = Color.Transparent;
            gradiend.SurroundColors = new Color[]
            {
                Color.FromArgb
                (
                  (int)(255 * ShadingOpacity),
                  CircleColor.R,
                  CircleColor.G,
                  CircleColor.B
                )
            };

            g.FillEllipse(gradiend, rect);
          }
        }
      }

      // circle
      using (var p = new Pen(CircleColor, CircleWidth))
      {
        g.DrawEllipse(p, rect);
      }

      // dots
      if (InnerCircle)
      {
        using (var p = new Pen(InnerCircleColor, InnerCircleWidth))
        {
          p.DashStyle = InnerCircleStyle;

          g.DrawEllipse
          (
            p,
            rect.X + InnerCircleOffset,
            rect.Y + InnerCircleOffset,
            rect.Width - (InnerCircleOffset * 2),
            rect.Height - (InnerCircleOffset * 2)
          );
        }
      }
    }

    /// <summary>
    /// Draws line.
    /// </summary>
    /// <param name="g">The <see cref="Graphics"/> instance.</param>
    /// <param name="rect">The <see cref="Rectangle"/> of the circle.</param>
    private void DrawLine(Graphics g, Rectangle rect)
    {
      using (var p = new Pen(LineColor, LineWidth))
      {
        int x1 = (rect.Width / 2) + rect.Left;
        int y1 = (rect.Height / 2) + rect.Top;

        int x2 = rect.Width - LineCut;
        int y2 = y1;

        using (var path = new GraphicsPath())
        {
          using (var matrix = new Matrix())
          {
            path.AddLine(new Point(x1, y1), new Point(x2, y2));
            matrix.RotateAt(-Value, new Point(x1, y1));
            path.Transform(matrix);

            p.DashStyle = LineStyle;
            p.EndCap = LineCap;

            g.DrawPath(p, path);
          }
        }
      }
    }

    /// <summary>
    /// Draws core.
    /// </summary>
    /// <param name="g">The <see cref="Graphics"/> instance.</param>
    /// <param name="rect">The <see cref="Rectangle"/> of the circle.</param>
    private void DrawPoint(Graphics g, Rectangle rect)
    {
      if (CoreType == CoreType.None)
      {
        return;
      }

      using (var b = new SolidBrush(CoreColor))
      {
        if (CoreType == CoreType.Ellipse)
        {
          g.FillEllipse
          (
            b,
            ((rect.Width - CoreWidth) / 2) + rect.Left,
            ((rect.Height - CoreWidth) / 2) + rect.Top,
            CoreWidth,
            CoreWidth
          );
        }
        else
        {
          g.FillRectangle
          (
            b,
            ((rect.Width - CoreWidth) / 2) + rect.Left,
            ((rect.Height - CoreWidth) / 2) + rect.Top,
            CoreWidth,
            CoreWidth
          );
        }
      }
    }

    /// <summary>
    /// Converts point to angle and sets value.
    /// </summary>
    /// <param name="p">The <see cref="Point"/>Point to processing.</param>
    private void SetAngle(Point p)
    {
      int w = ClientSize.Width - 2;
      int h = ClientSize.Height - 2;

      int x = w / 2;
      int y = h / 2;

      double d = 0;

      if (p.X - x == 0)
      {
        if (p.Y > y)
        {
          d = 90;
        }
        else
        {
          d = -90;
        }
      }
      else
      {
        double r = Math.Atan(Convert.ToDouble(p.Y - y) / Convert.ToDouble(p.X - x));

        d = r * (180 / Math.PI);

        if ((p.X - x) < 0 || (p.Y - y) < 0)
        {
          d += 180;

          if ((p.X - x) > 0 && (p.Y - y) < 0)
          {
            d -= 180;
          }

          if (d > 180)
          {
            d -= 360;
          }
        }
      }

      Value = -Convert.ToInt32(d);
    }

    /// <summary>
    /// Checks the incoming value, normalizes it and passes to value property.
    /// </summary>
    /// <param name="value">The value to check and set.</param>
    private void SetValue(int value)
    {
      if (value == Value)
      {
        return;
      }

      if (value < -180)
      {
        Value = 180 + (value + 180);
      }
      else if (value > 180)
      {
        Value = -180 + (value - 180);
      }
      else
      {
        Value = value;
      }
    }
  }
}