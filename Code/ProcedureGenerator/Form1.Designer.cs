
namespace ProcedureGenerator
{
    partial class Procedure_Generator
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procedure_Generator));
            this.Generate_btn = new System.Windows.Forms.Button();
            this.WorldPicture = new System.Windows.Forms.PictureBox();
            this.WorldGrad = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Seed_Box = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.PosX = new System.Windows.Forms.TextBox();
            this.Coordinates = new System.Windows.Forms.TextBox();
            this.ChangeCord = new System.Windows.Forms.Button();
            this.PosY = new System.Windows.Forms.TextBox();
            this.ChunkY = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ChunkX = new System.Windows.Forms.TextBox();
            this.MiniMapMode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.WorldPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Generate_btn
            // 
            this.Generate_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate_btn.Location = new System.Drawing.Point(478, 438);
            this.Generate_btn.Name = "Generate_btn";
            this.Generate_btn.Size = new System.Drawing.Size(100, 23);
            this.Generate_btn.TabIndex = 0;
            this.Generate_btn.Text = "Generate";
            this.Generate_btn.UseVisualStyleBackColor = true;
            this.Generate_btn.Click += new System.EventHandler(this.Generate_btn_Click);
            // 
            // WorldPicture
            // 
            this.WorldPicture.Location = new System.Drawing.Point(13, 13);
            this.WorldPicture.Name = "WorldPicture";
            this.WorldPicture.Size = new System.Drawing.Size(200, 200);
            this.WorldPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WorldPicture.TabIndex = 1;
            this.WorldPicture.TabStop = false;
            // 
            // WorldGrad
            // 
            this.WorldGrad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WorldGrad.Location = new System.Drawing.Point(118, 438);
            this.WorldGrad.Name = "WorldGrad";
            this.WorldGrad.Size = new System.Drawing.Size(135, 20);
            this.WorldGrad.TabIndex = 2;
            this.WorldGrad.Text = "8";
            this.WorldGrad.TextChanged += new System.EventHandler(this.WorldGrad_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(118, 422);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(135, 13);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "World size(2^n + 1)";
            // 
            // Seed_Box
            // 
            this.Seed_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Seed_Box.Location = new System.Drawing.Point(12, 438);
            this.Seed_Box.Name = "Seed_Box";
            this.Seed_Box.Size = new System.Drawing.Size(100, 20);
            this.Seed_Box.TabIndex = 4;
            this.Seed_Box.Text = "1";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(12, 422);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 13);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "World seed";
            // 
            // PosX
            // 
            this.PosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PosX.Location = new System.Drawing.Point(12, 396);
            this.PosX.Name = "PosX";
            this.PosX.Size = new System.Drawing.Size(45, 20);
            this.PosX.TabIndex = 7;
            this.PosX.Text = "0";
            // 
            // Coordinates
            // 
            this.Coordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Coordinates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Coordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Coordinates.Location = new System.Drawing.Point(12, 377);
            this.Coordinates.Name = "Coordinates";
            this.Coordinates.ReadOnly = true;
            this.Coordinates.Size = new System.Drawing.Size(100, 13);
            this.Coordinates.TabIndex = 8;
            this.Coordinates.Text = "Coordinates (x;y)";
            // 
            // ChangeCord
            // 
            this.ChangeCord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangeCord.Location = new System.Drawing.Point(118, 396);
            this.ChangeCord.Name = "ChangeCord";
            this.ChangeCord.Size = new System.Drawing.Size(100, 23);
            this.ChangeCord.TabIndex = 10;
            this.ChangeCord.Text = "Change";
            this.ChangeCord.UseVisualStyleBackColor = true;
            this.ChangeCord.Click += new System.EventHandler(this.ChangeCord_Click);
            // 
            // PosY
            // 
            this.PosY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PosY.Location = new System.Drawing.Point(67, 396);
            this.PosY.Name = "PosY";
            this.PosY.Size = new System.Drawing.Size(45, 20);
            this.PosY.TabIndex = 12;
            this.PosY.Text = "0";
            // 
            // ChunkY
            // 
            this.ChunkY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChunkY.Location = new System.Drawing.Point(314, 438);
            this.ChunkY.Name = "ChunkY";
            this.ChunkY.ReadOnly = true;
            this.ChunkY.Size = new System.Drawing.Size(45, 20);
            this.ChunkY.TabIndex = 15;
            this.ChunkY.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(259, 419);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 13);
            this.textBox4.TabIndex = 14;
            this.textBox4.Text = "Chunks XY";
            // 
            // ChunkX
            // 
            this.ChunkX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChunkX.Location = new System.Drawing.Point(259, 438);
            this.ChunkX.Name = "ChunkX";
            this.ChunkX.ReadOnly = true;
            this.ChunkX.Size = new System.Drawing.Size(45, 20);
            this.ChunkX.TabIndex = 13;
            this.ChunkX.Text = "0";
            // 
            // MiniMapMode
            // 
            this.MiniMapMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MiniMapMode.AutoSize = true;
            this.MiniMapMode.Location = new System.Drawing.Point(406, 439);
            this.MiniMapMode.Name = "MiniMapMode";
            this.MiniMapMode.Size = new System.Drawing.Size(66, 17);
            this.MiniMapMode.TabIndex = 16;
            this.MiniMapMode.Text = "MiniMap";
            this.MiniMapMode.UseVisualStyleBackColor = true;
            this.MiniMapMode.CheckedChanged += new System.EventHandler(this.MiniMapMode_CheckedChanged);
            // 
            // Procedure_Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(590, 473);
            this.Controls.Add(this.MiniMapMode);
            this.Controls.Add(this.ChunkY);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.ChunkX);
            this.Controls.Add(this.PosY);
            this.Controls.Add(this.ChangeCord);
            this.Controls.Add(this.Coordinates);
            this.Controls.Add(this.PosX);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.Seed_Box);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.WorldGrad);
            this.Controls.Add(this.WorldPicture);
            this.Controls.Add(this.Generate_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Procedure_Generator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procedural generator";
            this.Load += new System.EventHandler(this.Procedure_Generator_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Procedure_Generator_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.WorldPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate_btn;
        public System.Windows.Forms.PictureBox WorldPicture;
        private System.Windows.Forms.TextBox WorldGrad;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox Seed_Box;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox PosX;
        private System.Windows.Forms.TextBox Coordinates;
        private System.Windows.Forms.Button ChangeCord;
        private System.Windows.Forms.TextBox PosY;
        private System.Windows.Forms.TextBox ChunkY;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox ChunkX;
        private System.Windows.Forms.CheckBox MiniMapMode;
    }
}

