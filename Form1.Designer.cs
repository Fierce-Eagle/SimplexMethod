
namespace Form_ISO_Lr6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.freeVariableButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.freeMemberCollumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.basisVariableButton = new System.Windows.Forms.Button();
            this.solutionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FreeMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.removeBaseVariableButton = new System.Windows.Forms.Button();
            this.removeFreeVariableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // freeVariableButton
            // 
            this.freeVariableButton.Location = new System.Drawing.Point(453, 68);
            this.freeVariableButton.Name = "freeVariableButton";
            this.freeVariableButton.Size = new System.Drawing.Size(176, 46);
            this.freeVariableButton.TabIndex = 0;
            this.freeVariableButton.Text = "Добавить выражение";
            this.freeVariableButton.UseVisualStyleBackColor = true;
            this.freeVariableButton.Click += new System.EventHandler(this.FreeVariablesButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.freeMemberCollumn,
            this.Sign});
            this.dataGridView.Location = new System.Drawing.Point(13, 13);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(434, 188);
            this.dataGridView.TabIndex = 1;
            // 
            // freeMemberCollumn
            // 
            this.freeMemberCollumn.FillWeight = 80F;
            this.freeMemberCollumn.HeaderText = "Свободные члены";
            this.freeMemberCollumn.Name = "freeMemberCollumn";
            this.freeMemberCollumn.Width = 80;
            // 
            // Sign
            // 
            this.Sign.FillWeight = 65F;
            this.Sign.HeaderText = "Знак";
            this.Sign.Items.AddRange(new object[] {
            "=>",
            "<="});
            this.Sign.Name = "Sign";
            this.Sign.Width = 65;
            // 
            // basisVariableButton
            // 
            this.basisVariableButton.Location = new System.Drawing.Point(453, 13);
            this.basisVariableButton.Name = "basisVariableButton";
            this.basisVariableButton.Size = new System.Drawing.Size(176, 49);
            this.basisVariableButton.TabIndex = 2;
            this.basisVariableButton.Text = "Добавить переменную";
            this.basisVariableButton.UseVisualStyleBackColor = true;
            this.basisVariableButton.Click += new System.EventHandler(this.AddVariableButton_Click);
            // 
            // solutionButton
            // 
            this.solutionButton.Location = new System.Drawing.Point(452, 239);
            this.solutionButton.Name = "solutionButton";
            this.solutionButton.Size = new System.Drawing.Size(176, 55);
            this.solutionButton.TabIndex = 3;
            this.solutionButton.Text = "Решить систему";
            this.solutionButton.UseVisualStyleBackColor = true;
            this.solutionButton.Click += new System.EventHandler(this.SolutionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Решение системы";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(166, 310);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(462, 23);
            this.textBox.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn1,
            this.FreeMember});
            this.dataGridView1.Location = new System.Drawing.Point(14, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(433, 64);
            this.dataGridView1.TabIndex = 6;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.FillWeight = 65F;
            this.dataGridViewComboBoxColumn1.HeaderText = "Критерий опт.";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "Max",
            "Min"});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 65;
            // 
            // FreeMember
            // 
            this.FreeMember.FillWeight = 80F;
            this.FreeMember.HeaderText = "Свободные члены";
            this.FreeMember.Name = "FreeMember";
            this.FreeMember.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Функция цели";
            // 
            // removeBaseVariableButton
            // 
            this.removeBaseVariableButton.Location = new System.Drawing.Point(452, 120);
            this.removeBaseVariableButton.Name = "removeBaseVariableButton";
            this.removeBaseVariableButton.Size = new System.Drawing.Size(176, 52);
            this.removeBaseVariableButton.TabIndex = 8;
            this.removeBaseVariableButton.Text = "Удалить переменную";
            this.removeBaseVariableButton.UseVisualStyleBackColor = true;
            this.removeBaseVariableButton.Click += new System.EventHandler(this.RemoveVariableButton_Click);
            // 
            // removeFreeVariableButton
            // 
            this.removeFreeVariableButton.Location = new System.Drawing.Point(452, 178);
            this.removeFreeVariableButton.Name = "removeFreeVariableButton";
            this.removeFreeVariableButton.Size = new System.Drawing.Size(176, 55);
            this.removeFreeVariableButton.TabIndex = 9;
            this.removeFreeVariableButton.Text = "Удалить выражение";
            this.removeFreeVariableButton.UseVisualStyleBackColor = true;
            this.removeFreeVariableButton.Click += new System.EventHandler(this.RemoveFreeVariableButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 346);
            this.Controls.Add(this.removeFreeVariableButton);
            this.Controls.Add(this.removeBaseVariableButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solutionButton);
            this.Controls.Add(this.basisVariableButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.freeVariableButton);
            this.Name = "Form1";
            this.Text = resources.GetString("$this.Text");
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button freeVariableButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button basisVariableButton;
        private System.Windows.Forms.Button solutionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeBaseVariableButton;
        private System.Windows.Forms.Button removeFreeVariableButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn freeMemberCollumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Sign;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeMember;
    }
}

