namespace OneAttributeBulkUpload
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadEntitiesButton = new System.Windows.Forms.Button();
            this.selectEntitiesComboBox = new System.Windows.Forms.ComboBox();
            this.selectAttributeComboBox = new System.Windows.Forms.ComboBox();
            this.targetEntityComboBox = new System.Windows.Forms.ComboBox();
            this.targetAttributecomboBox = new System.Windows.Forms.ComboBox();
            this.selectUniqueAttributeComboBox = new System.Windows.Forms.ComboBox();
            this.fileNameTextBox = new System.Windows.Forms.MaskedTextBox();
            this.delimeterTextBox = new System.Windows.Forms.MaskedTextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.proceedToLoadButton = new System.Windows.Forms.Button();
            this.SelectEntityLable = new System.Windows.Forms.Label();
            this.selectAttrbuteUpdLabel = new System.Windows.Forms.Label();
            this.attributeUpdNoteLabel = new System.Windows.Forms.Label();
            this.entityRefLable1 = new System.Windows.Forms.Label();
            this.entityReferenceLable2 = new System.Windows.Forms.Label();
            this.firstColumnLable1 = new System.Windows.Forms.Label();
            this.firstColumnNoteLabel = new System.Windows.Forms.Label();
            this.selectFileLabel = new System.Windows.Forms.Label();
            this.delimeterSelectLabel = new System.Windows.Forms.Label();
            this.logsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.notesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.targetEntityNameLable = new System.Windows.Forms.Label();
            this.targetEntityAttrLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ActiveRecordsLabel = new System.Windows.Forms.Label();
            this.activeRecordsCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadEntitiesButton
            // 
            this.LoadEntitiesButton.Location = new System.Drawing.Point(26, 33);
            this.LoadEntitiesButton.Name = "LoadEntitiesButton";
            this.LoadEntitiesButton.Size = new System.Drawing.Size(546, 40);
            this.LoadEntitiesButton.TabIndex = 0;
            this.LoadEntitiesButton.Text = "Load Entities";
            this.LoadEntitiesButton.UseVisualStyleBackColor = true;
            this.LoadEntitiesButton.Click += new System.EventHandler(this.LoadEntitiesButton_Click);
            // 
            // selectEntitiesComboBox
            // 
            this.selectEntitiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectEntitiesComboBox.FormattingEnabled = true;
            this.selectEntitiesComboBox.Location = new System.Drawing.Point(298, 99);
            this.selectEntitiesComboBox.Name = "selectEntitiesComboBox";
            this.selectEntitiesComboBox.Size = new System.Drawing.Size(274, 21);
            this.selectEntitiesComboBox.TabIndex = 2;
            this.selectEntitiesComboBox.SelectionChangeCommitted += new System.EventHandler(this.OnEntitySelect);
            // 
            // selectAttributeComboBox
            // 
            this.selectAttributeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectAttributeComboBox.FormattingEnabled = true;
            this.selectAttributeComboBox.Location = new System.Drawing.Point(298, 150);
            this.selectAttributeComboBox.Name = "selectAttributeComboBox";
            this.selectAttributeComboBox.Size = new System.Drawing.Size(274, 21);
            this.selectAttributeComboBox.TabIndex = 3;
            this.selectAttributeComboBox.SelectionChangeCommitted += new System.EventHandler(this.OnUpdAttributeSelect);
            // 
            // targetEntityComboBox
            // 
            this.targetEntityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetEntityComboBox.FormattingEnabled = true;
            this.targetEntityComboBox.Location = new System.Drawing.Point(298, 235);
            this.targetEntityComboBox.Name = "targetEntityComboBox";
            this.targetEntityComboBox.Size = new System.Drawing.Size(134, 21);
            this.targetEntityComboBox.TabIndex = 4;
            this.targetEntityComboBox.Visible = false;
            this.targetEntityComboBox.SelectionChangeCommitted += new System.EventHandler(this.OnSelectTargetEntity);
            // 
            // targetAttributecomboBox
            // 
            this.targetAttributecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetAttributecomboBox.FormattingEnabled = true;
            this.targetAttributecomboBox.Location = new System.Drawing.Point(434, 235);
            this.targetAttributecomboBox.Name = "targetAttributecomboBox";
            this.targetAttributecomboBox.Size = new System.Drawing.Size(138, 21);
            this.targetAttributecomboBox.TabIndex = 5;
            this.targetAttributecomboBox.Visible = false;
            // 
            // selectUniqueAttributeComboBox
            // 
            this.selectUniqueAttributeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectUniqueAttributeComboBox.FormattingEnabled = true;
            this.selectUniqueAttributeComboBox.Location = new System.Drawing.Point(298, 309);
            this.selectUniqueAttributeComboBox.Name = "selectUniqueAttributeComboBox";
            this.selectUniqueAttributeComboBox.Size = new System.Drawing.Size(274, 21);
            this.selectUniqueAttributeComboBox.TabIndex = 6;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Enabled = false;
            this.fileNameTextBox.Location = new System.Drawing.Point(298, 368);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(274, 20);
            this.fileNameTextBox.TabIndex = 8;
            // 
            // delimeterTextBox
            // 
            this.delimeterTextBox.Location = new System.Drawing.Point(298, 433);
            this.delimeterTextBox.Name = "delimeterTextBox";
            this.delimeterTextBox.Size = new System.Drawing.Size(274, 20);
            this.delimeterTextBox.TabIndex = 9;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(569, 368);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(87, 20);
            this.browseButton.TabIndex = 10;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // proceedToLoadButton
            // 
            this.proceedToLoadButton.Location = new System.Drawing.Point(334, 509);
            this.proceedToLoadButton.Name = "proceedToLoadButton";
            this.proceedToLoadButton.Size = new System.Drawing.Size(204, 32);
            this.proceedToLoadButton.TabIndex = 11;
            this.proceedToLoadButton.Text = "Proceed To Load";
            this.proceedToLoadButton.UseVisualStyleBackColor = true;
            this.proceedToLoadButton.Click += new System.EventHandler(this.proceedToLoadButton_Click);
            // 
            // SelectEntityLable
            // 
            this.SelectEntityLable.AutoSize = true;
            this.SelectEntityLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectEntityLable.Location = new System.Drawing.Point(39, 98);
            this.SelectEntityLable.Name = "SelectEntityLable";
            this.SelectEntityLable.Size = new System.Drawing.Size(120, 22);
            this.SelectEntityLable.TabIndex = 14;
            this.SelectEntityLable.Text = "Select Entity :";
            // 
            // selectAttrbuteUpdLabel
            // 
            this.selectAttrbuteUpdLabel.AutoSize = true;
            this.selectAttrbuteUpdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAttrbuteUpdLabel.Location = new System.Drawing.Point(39, 149);
            this.selectAttrbuteUpdLabel.Name = "selectAttrbuteUpdLabel";
            this.selectAttrbuteUpdLabel.Size = new System.Drawing.Size(253, 22);
            this.selectAttrbuteUpdLabel.TabIndex = 15;
            this.selectAttrbuteUpdLabel.Text = "Select Attrbute to be updated :";
            // 
            // attributeUpdNoteLabel
            // 
            this.attributeUpdNoteLabel.ForeColor = System.Drawing.Color.Red;
            this.attributeUpdNoteLabel.Location = new System.Drawing.Point(357, 174);
            this.attributeUpdNoteLabel.Name = "attributeUpdNoteLabel";
            this.attributeUpdNoteLabel.Size = new System.Drawing.Size(285, 27);
            this.attributeUpdNoteLabel.TabIndex = 31;
            this.attributeUpdNoteLabel.Text = "Note: The value of this Attrbute should be second column in the file selected for" +
    " upload";
            this.attributeUpdNoteLabel.Visible = false;
            // 
            // entityRefLable1
            // 
            this.entityRefLable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityRefLable1.Location = new System.Drawing.Point(40, 220);
            this.entityRefLable1.Name = "entityRefLable1";
            this.entityRefLable1.Size = new System.Drawing.Size(252, 60);
            this.entityRefLable1.TabIndex = 32;
            this.entityRefLable1.Text = "Attribute selected is a Reference type. Please select the Target Entity and Attri" +
    "bute";
            this.entityRefLable1.Visible = false;
            // 
            // entityReferenceLable2
            // 
            this.entityReferenceLable2.ForeColor = System.Drawing.Color.Red;
            this.entityReferenceLable2.Location = new System.Drawing.Point(400, 259);
            this.entityReferenceLable2.Name = "entityReferenceLable2";
            this.entityReferenceLable2.Size = new System.Drawing.Size(242, 38);
            this.entityReferenceLable2.TabIndex = 33;
            this.entityReferenceLable2.Text = "Note: The value of this Attrbute should be second column in the file selected for" +
    " upload";
            this.entityReferenceLable2.Visible = false;
            // 
            // firstColumnLable1
            // 
            this.firstColumnLable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstColumnLable1.Location = new System.Drawing.Point(40, 299);
            this.firstColumnLable1.Name = "firstColumnLable1";
            this.firstColumnLable1.Size = new System.Drawing.Size(252, 45);
            this.firstColumnLable1.TabIndex = 34;
            this.firstColumnLable1.Text = "Please select the unique Attribute for this load:";
            // 
            // firstColumnNoteLabel
            // 
            this.firstColumnNoteLabel.ForeColor = System.Drawing.Color.Red;
            this.firstColumnNoteLabel.Location = new System.Drawing.Point(400, 333);
            this.firstColumnNoteLabel.Name = "firstColumnNoteLabel";
            this.firstColumnNoteLabel.Size = new System.Drawing.Size(242, 32);
            this.firstColumnNoteLabel.TabIndex = 35;
            this.firstColumnNoteLabel.Text = "Note: This Attribute should be the first column in the file selected for upload ";
            // 
            // selectFileLabel
            // 
            this.selectFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileLabel.Location = new System.Drawing.Point(39, 366);
            this.selectFileLabel.Name = "selectFileLabel";
            this.selectFileLabel.Size = new System.Drawing.Size(197, 42);
            this.selectFileLabel.TabIndex = 36;
            this.selectFileLabel.Text = "Select File To Process:";
            // 
            // delimeterSelectLabel
            // 
            this.delimeterSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delimeterSelectLabel.Location = new System.Drawing.Point(39, 429);
            this.delimeterSelectLabel.Name = "delimeterSelectLabel";
            this.delimeterSelectLabel.Size = new System.Drawing.Size(197, 29);
            this.delimeterSelectLabel.TabIndex = 37;
            this.delimeterSelectLabel.Text = "Delimeter of the file:";
            // 
            // logsRichTextBox
            // 
            this.logsRichTextBox.Location = new System.Drawing.Point(698, 151);
            this.logsRichTextBox.Name = "logsRichTextBox";
            this.logsRichTextBox.Size = new System.Drawing.Size(571, 403);
            this.logsRichTextBox.TabIndex = 38;
            this.logsRichTextBox.Text = "";
            // 
            // notesLabel
            // 
            this.notesLabel.AutoSize = true;
            this.notesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.notesLabel.Location = new System.Drawing.Point(695, 21);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.Size = new System.Drawing.Size(46, 13);
            this.notesLabel.TabIndex = 41;
            this.notesLabel.Text = "Note : ";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(694, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 18);
            this.label1.TabIndex = 42;
            this.label1.Text = "> For Option set values to be updated, pass the integer values of Option set valu" +
    "es";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(694, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(637, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = "> For DateTime attrbutes to be updated, pass the date values in \"M/d/yyyy h:mm\" f" +
    "ormat, for e.g. \"5/30/2020 12:00\"";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(694, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(449, 18);
            this.label3.TabIndex = 44;
            this.label3.Text = "> For Boolean/Two Options to be updated, pass the string values, for e.g true, fa" +
    "lse";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(694, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(449, 18);
            this.label4.TabIndex = 45;
            this.label4.Text = "> For Money/Currency values to be updated, pass the decimal values, for e.g. 1220" +
    ".50 ";
            // 
            // targetEntityNameLable
            // 
            this.targetEntityNameLable.AutoSize = true;
            this.targetEntityNameLable.Location = new System.Drawing.Point(317, 219);
            this.targetEntityNameLable.Name = "targetEntityNameLable";
            this.targetEntityNameLable.Size = new System.Drawing.Size(98, 13);
            this.targetEntityNameLable.TabIndex = 46;
            this.targetEntityNameLable.Text = "Target Entity Name";
            this.targetEntityNameLable.Visible = false;
            // 
            // targetEntityAttrLabel
            // 
            this.targetEntityAttrLabel.AutoSize = true;
            this.targetEntityAttrLabel.Location = new System.Drawing.Point(451, 219);
            this.targetEntityAttrLabel.Name = "targetEntityAttrLabel";
            this.targetEntityAttrLabel.Size = new System.Drawing.Size(109, 13);
            this.targetEntityAttrLabel.TabIndex = 47;
            this.targetEntityAttrLabel.Text = "Target Entity Attribute";
            this.targetEntityAttrLabel.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(694, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(449, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "> This bulk load is limited to 1000 record at a time";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(695, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 49;
            this.label6.Text = "Logs :";
            // 
            // ActiveRecordsLabel
            // 
            this.ActiveRecordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActiveRecordsLabel.Location = new System.Drawing.Point(40, 472);
            this.ActiveRecordsLabel.Name = "ActiveRecordsLabel";
            this.ActiveRecordsLabel.Size = new System.Drawing.Size(252, 45);
            this.ActiveRecordsLabel.TabIndex = 50;
            this.ActiveRecordsLabel.Text = "Consider only Active Records for Update ?";
            // 
            // activeRecordsCheckBox
            // 
            this.activeRecordsCheckBox.AutoSize = true;
            this.activeRecordsCheckBox.Location = new System.Drawing.Point(299, 472);
            this.activeRecordsCheckBox.Name = "activeRecordsCheckBox";
            this.activeRecordsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.activeRecordsCheckBox.TabIndex = 51;
            this.activeRecordsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(374, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(318, 32);
            this.label7.TabIndex = 52;
            this.label7.Text = "Note : Expected File Extenstion is txt. First column and Second column values sho" +
    "uld be seperated by delimeter specified";
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.activeRecordsCheckBox);
            this.Controls.Add(this.ActiveRecordsLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.targetEntityAttrLabel);
            this.Controls.Add(this.targetEntityNameLable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notesLabel);
            this.Controls.Add(this.logsRichTextBox);
            this.Controls.Add(this.delimeterSelectLabel);
            this.Controls.Add(this.selectFileLabel);
            this.Controls.Add(this.firstColumnNoteLabel);
            this.Controls.Add(this.firstColumnLable1);
            this.Controls.Add(this.entityReferenceLable2);
            this.Controls.Add(this.entityRefLable1);
            this.Controls.Add(this.attributeUpdNoteLabel);
            this.Controls.Add(this.selectAttrbuteUpdLabel);
            this.Controls.Add(this.SelectEntityLable);
            this.Controls.Add(this.proceedToLoadButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.delimeterTextBox);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.selectUniqueAttributeComboBox);
            this.Controls.Add(this.targetAttributecomboBox);
            this.Controls.Add(this.targetEntityComboBox);
            this.Controls.Add(this.selectAttributeComboBox);
            this.Controls.Add(this.selectEntitiesComboBox);
            this.Controls.Add(this.LoadEntitiesButton);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1351, 577);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadEntitiesButton;
        private System.Windows.Forms.ComboBox selectEntitiesComboBox;
        private System.Windows.Forms.ComboBox selectAttributeComboBox;
        private System.Windows.Forms.ComboBox targetEntityComboBox;
        private System.Windows.Forms.ComboBox targetAttributecomboBox;
        private System.Windows.Forms.ComboBox selectUniqueAttributeComboBox;
        private System.Windows.Forms.MaskedTextBox fileNameTextBox;
        private System.Windows.Forms.MaskedTextBox delimeterTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button proceedToLoadButton;
        private System.Windows.Forms.Label SelectEntityLable;
        private System.Windows.Forms.Label selectAttrbuteUpdLabel;
        private System.Windows.Forms.Label attributeUpdNoteLabel;
        private System.Windows.Forms.Label entityRefLable1;
        private System.Windows.Forms.Label entityReferenceLable2;
        private System.Windows.Forms.Label firstColumnLable1;
        private System.Windows.Forms.Label firstColumnNoteLabel;
        private System.Windows.Forms.Label selectFileLabel;
        private System.Windows.Forms.Label delimeterSelectLabel;
        private System.Windows.Forms.RichTextBox logsRichTextBox;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label targetEntityNameLable;
        private System.Windows.Forms.Label targetEntityAttrLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ActiveRecordsLabel;
        private System.Windows.Forms.CheckBox activeRecordsCheckBox;
        private System.Windows.Forms.Label label7;
    }
}
