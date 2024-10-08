namespace Test
{
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
            Buscar = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            Seleccionar = new Button();
            label2 = new Label();
            listBox1 = new ListBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // Buscar
            // 
            Buscar.Location = new Point(514, 281);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(94, 29);
            Buscar.TabIndex = 0;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 23);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 1;
            label1.Text = "Seleccioni el fitxer";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(56, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(452, 27);
            textBox1.TabIndex = 2;
            // 
            // Seleccionar
            // 
            Seleccionar.Location = new Point(514, 44);
            Seleccionar.Name = "Seleccionar";
            Seleccionar.Size = new Size(94, 29);
            Seleccionar.TabIndex = 3;
            Seleccionar.Text = "Seleccionar";
            Seleccionar.UseVisualStyleBackColor = true;
            Seleccionar.Click += Seleccionar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 255);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 4;
            label2.Text = "Nom del fitxer";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(56, 88);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(552, 164);
            listBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(56, 278);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(452, 27);
            textBox2.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 333);
            Controls.Add(textBox2);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(Seleccionar);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(Buscar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Buscar;
        private Label label1;
        private TextBox textBox1;
        private Button Seleccionar;
        private Label label2;
        private ListBox listBox1;
        private TextBox textBox2;
    }
}
