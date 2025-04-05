namespace Proyecto_Catedra_PED.Categorias
{
    partial class Carrito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.area = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gp2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbtotal = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cantidad = new System.Windows.Forms.NumericUpDown();
            this.lbnombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AgrNodo = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk25 = new System.Windows.Forms.CheckBox();
            this.chk20 = new System.Windows.Forms.CheckBox();
            this.chk10 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbpago = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.gp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.area.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.area.Location = new System.Drawing.Point(154, 122);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(596, 260);
            this.area.TabIndex = 0;
            this.area.TabStop = false;
            this.area.Text = "Productos deseados";
            this.area.Enter += new System.EventHandler(this.gp1_Enter);
            this.area.MouseHover += new System.EventHandler(this.area_MouseHover);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(813, 407);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(155, 40);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar compra";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // gp2
            // 
            this.gp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gp2.Controls.Add(this.button1);
            this.gp2.Controls.Add(this.lbtotal);
            this.gp2.Controls.Add(this.btnNuevo);
            this.gp2.Controls.Add(this.label3);
            this.gp2.Controls.Add(this.cantidad);
            this.gp2.Controls.Add(this.lbnombre);
            this.gp2.Controls.Add(this.label1);
            this.gp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp2.Location = new System.Drawing.Point(770, 122);
            this.gp2.Name = "gp2";
            this.gp2.Size = new System.Drawing.Size(298, 123);
            this.gp2.TabIndex = 2;
            this.gp2.TabStop = false;
            this.gp2.Text = "Procesos";
            this.gp2.Enter += new System.EventHandler(this.gp2_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbtotal
            // 
            this.lbtotal.AutoSize = true;
            this.lbtotal.Location = new System.Drawing.Point(103, 100);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(15, 15);
            this.lbtotal.TabIndex = 8;
            this.lbtotal.Text = "#";
            this.lbtotal.Click += new System.EventHandler(this.lbtotal_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(214, 20);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(78, 37);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Aceptar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(78, 54);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(122, 21);
            this.cantidad.TabIndex = 6;
            this.cantidad.ValueChanged += new System.EventHandler(this.cantidad_ValueChanged);
            // 
            // lbnombre
            // 
            this.lbnombre.AutoSize = true;
            this.lbnombre.Location = new System.Drawing.Point(40, 25);
            this.lbnombre.Name = "lbnombre";
            this.lbnombre.Size = new System.Drawing.Size(142, 15);
            this.lbnombre.TabIndex = 5;
            this.lbnombre.Text = "Nombre del producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "cantidad";
            // 
            // AgrNodo
            // 
            this.AgrNodo.Tick += new System.EventHandler(this.AgrNodo_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.chk25);
            this.groupBox1.Controls.Add(this.chk20);
            this.groupBox1.Controls.Add(this.chk10);
            this.groupBox1.Location = new System.Drawing.Point(984, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 173);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descuentos";
            // 
            // chk25
            // 
            this.chk25.AutoSize = true;
            this.chk25.Enabled = false;
            this.chk25.Location = new System.Drawing.Point(41, 117);
            this.chk25.Name = "chk25";
            this.chk25.Size = new System.Drawing.Size(46, 17);
            this.chk25.TabIndex = 2;
            this.chk25.Text = "25%";
            this.chk25.UseVisualStyleBackColor = true;
            // 
            // chk20
            // 
            this.chk20.AutoSize = true;
            this.chk20.Enabled = false;
            this.chk20.Location = new System.Drawing.Point(41, 83);
            this.chk20.Name = "chk20";
            this.chk20.Size = new System.Drawing.Size(46, 17);
            this.chk20.TabIndex = 1;
            this.chk20.Text = "20%";
            this.chk20.UseVisualStyleBackColor = true;
            // 
            // chk10
            // 
            this.chk10.AutoSize = true;
            this.chk10.Enabled = false;
            this.chk10.Location = new System.Drawing.Point(41, 41);
            this.chk10.Name = "chk10";
            this.chk10.Size = new System.Drawing.Size(46, 17);
            this.chk10.TabIndex = 0;
            this.chk10.Text = "10%";
            this.chk10.UseVisualStyleBackColor = true;
            this.chk10.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(832, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Pago total";
            // 
            // lbpago
            // 
            this.lbpago.AutoSize = true;
            this.lbpago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpago.ForeColor = System.Drawing.Color.Red;
            this.lbpago.Location = new System.Drawing.Point(855, 334);
            this.lbpago.Name = "lbpago";
            this.lbpago.Size = new System.Drawing.Size(52, 18);
            this.lbpago.TabIndex = 27;
            this.lbpago.Text = "label4";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 21);
            this.button2.TabIndex = 28;
            this.button2.Text = "Vaciar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(512, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 39);
            this.label4.TabIndex = 29;
            this.label4.Text = "CARRITO  ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Proyecto_Catedra_PED.Properties.Resources.MascotaDelado_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(98, 375);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = global::Proyecto_Catedra_PED.Properties.Resources.Mascota_removebg_preview;
            this.pictureBox12.Location = new System.Drawing.Point(684, 375);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(94, 92);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 21;
            this.pictureBox12.TabStop = false;
            // 
            // Carrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1098, 507);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbpago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gp2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.area);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Carrito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carrito";
            this.Load += new System.EventHandler(this.Carrito_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Carrito_Paint);
            this.gp2.ResumeLayout(false);
            this.gp2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.GroupBox area;
        public System.Windows.Forms.GroupBox gp2;
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cantidad;
        private System.Windows.Forms.Label lbnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer AgrNodo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk25;
        private System.Windows.Forms.CheckBox chk20;
        private System.Windows.Forms.CheckBox chk10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbpago;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}