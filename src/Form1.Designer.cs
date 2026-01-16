namespace Commentator;

partial class Form1
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		tbRoot = new TextBox();
		label1 = new Label();
		button1 = new Button();
		tbList = new TextBox();
		button2 = new Button();
		SuspendLayout();
		// 
		// tbRoot
		// 
		tbRoot.Location = new Point(12, 33);
		tbRoot.Name = "tbRoot";
		tbRoot.Size = new Size(490, 23);
		tbRoot.TabIndex = 0;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(12, 15);
		label1.Name = "label1";
		label1.Size = new Size(31, 15);
		label1.TabIndex = 1;
		label1.Text = "path";
		// 
		// button1
		// 
		button1.Location = new Point(12, 90);
		button1.Name = "button1";
		button1.Size = new Size(75, 23);
		button1.TabIndex = 2;
		button1.Text = "List";
		button1.UseVisualStyleBackColor = true;
		button1.Click += button1_Click;
		// 
		// tbList
		// 
		tbList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tbList.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
		tbList.Location = new Point(12, 119);
		tbList.Multiline = true;
		tbList.Name = "tbList";
		tbList.ScrollBars = ScrollBars.Vertical;
		tbList.Size = new Size(782, 319);
		tbList.TabIndex = 3;
		// 
		// button2
		// 
		button2.Location = new Point(133, 90);
		button2.Name = "button2";
		button2.Size = new Size(75, 23);
		button2.TabIndex = 4;
		button2.Text = "Comment";
		button2.UseVisualStyleBackColor = true;
		button2.Click += button2_Click;
		// 
		// Form1
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(814, 450);
		Controls.Add(button2);
		Controls.Add(tbList);
		Controls.Add(button1);
		Controls.Add(label1);
		Controls.Add(tbRoot);
		Name = "Form1";
		Text = "Form1";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private TextBox tbRoot;
	private Label label1;
	private Button button1;
	private TextBox tbList;
	private Button button2;
}
