namespace System.Windows.Forms
{
  partial class CircleAnglePicker
  {
    /// <summary> 
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // CircleAnglePicker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.DoubleBuffered = true;
      this.Name = "CircleAnglePicker";
      this.Size = new System.Drawing.Size(32, 32);
      this.PaddingChanged += new System.EventHandler(this.CircleAnglePicker_PaddingChanged);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.CircleAnglePicker_Paint);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CircleAnglePicker_KeyDown);
      this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CircleAnglePicker_MouseClick);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CircleAnglePicker_MouseMove);
      this.Resize += new System.EventHandler(this.CircleAnglePicker_Resize);
      this.ResumeLayout(false);

    }

    #endregion
  }
}
