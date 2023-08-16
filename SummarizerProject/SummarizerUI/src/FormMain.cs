using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using SummaryLib;

namespace SummarizerUI
{
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox textBoxFullText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonSummarize;
		private System.Windows.Forms.TextBox textBoxSourceSentences;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxSummarySentences;
		private System.Windows.Forms.Label labelSourceTextSentenceCount;
		private System.Windows.Forms.Label labelSummarySentenceCount;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDownCompressionRate;
		private System.Windows.Forms.TextBox textBoxSourceTokens;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBoxSummaryMethod;
		private System.Windows.Forms.ComboBox comboBoxSentenceDisplayOrder;
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.comboBoxSummaryMethod = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.numericUpDownCompressionRate = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonClear = new System.Windows.Forms.Button();
			this.buttonSummarize = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFullText = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.labelSummarySentenceCount = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxSummarySentences = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textBoxSourceTokens = new System.Windows.Forms.TextBox();
			this.labelSourceTextSentenceCount = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxSourceSentences = new System.Windows.Forms.TextBox();
			this.comboBoxSentenceDisplayOrder = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompressionRate)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(632, 416);
			this.tabControl1.TabIndex = 5;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.comboBoxSentenceDisplayOrder);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.comboBoxSummaryMethod);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.numericUpDownCompressionRate);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.buttonClear);
			this.tabPage1.Controls.Add(this.buttonSummarize);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBoxFullText);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(624, 387);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Parameters";
			// 
			// comboBoxSummaryMethod
			// 
			this.comboBoxSummaryMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSummaryMethod.Items.AddRange(new object[] {
																	   "Term Frequency",
																	   "Luhn"});
			this.comboBoxSummaryMethod.Location = new System.Drawing.Point(184, 240);
			this.comboBoxSummaryMethod.Name = "comboBoxSummaryMethod";
			this.comboBoxSummaryMethod.Size = new System.Drawing.Size(176, 24);
			this.comboBoxSummaryMethod.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 240);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 18);
			this.label6.TabIndex = 7;
			this.label6.Text = "Summary Method:";
			// 
			// numericUpDownCompressionRate
			// 
			this.numericUpDownCompressionRate.Location = new System.Drawing.Point(184, 200);
			this.numericUpDownCompressionRate.Minimum = new System.Decimal(new int[] {
																						 1,
																						 0,
																						 0,
																						 0});
			this.numericUpDownCompressionRate.Name = "numericUpDownCompressionRate";
			this.numericUpDownCompressionRate.Size = new System.Drawing.Size(56, 22);
			this.numericUpDownCompressionRate.TabIndex = 1;
			this.numericUpDownCompressionRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownCompressionRate.Value = new System.Decimal(new int[] {
																					   10,
																					   0,
																					   0,
																					   0});
			this.numericUpDownCompressionRate.ValueChanged += new System.EventHandler(this.numericUpDownCompressionRate_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 18);
			this.label5.TabIndex = 6;
			this.label5.Text = "Compression Rate:";
			// 
			// buttonClear
			// 
			this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClear.Location = new System.Drawing.Point(352, 336);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(106, 28);
			this.buttonClear.TabIndex = 5;
			this.buttonClear.Text = "Clear";
			// 
			// buttonSummarize
			// 
			this.buttonSummarize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSummarize.Location = new System.Drawing.Point(472, 336);
			this.buttonSummarize.Name = "buttonSummarize";
			this.buttonSummarize.Size = new System.Drawing.Size(134, 28);
			this.buttonSummarize.TabIndex = 4;
			this.buttonSummarize.Text = "Summarize";
			this.buttonSummarize.Click += new System.EventHandler(this.buttonSummarize_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Source Text:";
			// 
			// textBoxFullText
			// 
			this.textBoxFullText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxFullText.Location = new System.Drawing.Point(16, 40);
			this.textBoxFullText.Multiline = true;
			this.textBoxFullText.Name = "textBoxFullText";
			this.textBoxFullText.Size = new System.Drawing.Size(592, 144);
			this.textBoxFullText.TabIndex = 0;
			this.textBoxFullText.Text = "";
			this.textBoxFullText.TextChanged += new System.EventHandler(this.textBoxFullText_TextChanged);
			this.textBoxFullText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFullText_KeyUp);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.labelSummarySentenceCount);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.textBoxSummarySentences);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(624, 387);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Summary";
			// 
			// labelSummarySentenceCount
			// 
			this.labelSummarySentenceCount.Location = new System.Drawing.Point(160, 16);
			this.labelSummarySentenceCount.Name = "labelSummarySentenceCount";
			this.labelSummarySentenceCount.Size = new System.Drawing.Size(147, 18);
			this.labelSummarySentenceCount.TabIndex = 11;
			this.labelSummarySentenceCount.Text = "(0)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(133, 18);
			this.label4.TabIndex = 10;
			this.label4.Text = "Summary Sentences:";
			// 
			// textBoxSummarySentences
			// 
			this.textBoxSummarySentences.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxSummarySentences.Location = new System.Drawing.Point(16, 40);
			this.textBoxSummarySentences.Multiline = true;
			this.textBoxSummarySentences.Name = "textBoxSummarySentences";
			this.textBoxSummarySentences.ReadOnly = true;
			this.textBoxSummarySentences.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSummarySentences.Size = new System.Drawing.Size(592, 328);
			this.textBoxSummarySentences.TabIndex = 6;
			this.textBoxSummarySentences.Text = "";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textBoxSourceTokens);
			this.tabPage3.Controls.Add(this.labelSourceTextSentenceCount);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.textBoxSourceSentences);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(624, 387);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Details";
			// 
			// textBoxSourceTokens
			// 
			this.textBoxSourceTokens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxSourceTokens.Location = new System.Drawing.Point(16, 40);
			this.textBoxSourceTokens.Multiline = true;
			this.textBoxSourceTokens.Name = "textBoxSourceTokens";
			this.textBoxSourceTokens.ReadOnly = true;
			this.textBoxSourceTokens.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSourceTokens.Size = new System.Drawing.Size(592, 104);
			this.textBoxSourceTokens.TabIndex = 7;
			this.textBoxSourceTokens.Text = "";
			// 
			// labelSourceTextSentenceCount
			// 
			this.labelSourceTextSentenceCount.Location = new System.Drawing.Point(168, 160);
			this.labelSourceTextSentenceCount.Name = "labelSourceTextSentenceCount";
			this.labelSourceTextSentenceCount.Size = new System.Drawing.Size(147, 18);
			this.labelSourceTextSentenceCount.TabIndex = 9;
			this.labelSourceTextSentenceCount.Text = "(0)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 18);
			this.label3.TabIndex = 8;
			this.label3.Text = "Source Text Sentences:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 18);
			this.label2.TabIndex = 7;
			this.label2.Text = "Source Text Tokens:";
			// 
			// textBoxSourceSentences
			// 
			this.textBoxSourceSentences.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxSourceSentences.Location = new System.Drawing.Point(16, 192);
			this.textBoxSourceSentences.Multiline = true;
			this.textBoxSourceSentences.Name = "textBoxSourceSentences";
			this.textBoxSourceSentences.ReadOnly = true;
			this.textBoxSourceSentences.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSourceSentences.Size = new System.Drawing.Size(592, 184);
			this.textBoxSourceSentences.TabIndex = 8;
			this.textBoxSourceSentences.Text = "";
			// 
			// comboBoxSentenceDisplayOrder
			// 
			this.comboBoxSentenceDisplayOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSentenceDisplayOrder.Items.AddRange(new object[] {
																			  "Order of appearance",
																			  "Highest scoring"});
			this.comboBoxSentenceDisplayOrder.Location = new System.Drawing.Point(184, 272);
			this.comboBoxSentenceDisplayOrder.Name = "comboBoxSentenceDisplayOrder";
			this.comboBoxSentenceDisplayOrder.Size = new System.Drawing.Size(176, 24);
			this.comboBoxSentenceDisplayOrder.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(24, 272);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(151, 18);
			this.label7.TabIndex = 9;
			this.label7.Text = "Sentence Display Order:";
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(652, 496);
			this.Controls.Add(this.tabControl1);
			this.Name = "FormMain";
			this.Text = "Text Summarizer";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompressionRate)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            this.textBoxFullText.Clear();
			this.textBoxSourceSentences.Clear();
			this.textBoxSourceTokens.Clear();
			this.textBoxSummarySentences.Clear();
        }

		private void buttonSummarize_Click(object sender, System.EventArgs e)
		{
			this.textBoxSourceSentences.Clear();
			this.textBoxSourceTokens.Clear();
			this.textBoxSummarySentences.Clear();
			this.labelSourceTextSentenceCount.Text = "(0)";
			this.labelSummarySentenceCount.Text = "(0)";

			// Get sentences
			ISentenceExtractor extractor = new SentenceExtractorSharpEntropy();
			SentenceCollection sentences = extractor.parseText(this.textBoxFullText.Text);
			this.labelSourceTextSentenceCount.Text = "(" + sentences.Count.ToString() + ")";

			// Summarize sentences
			ISummarizer summarizer = null;
			if (comboBoxSummaryMethod.SelectedIndex == 0)
				summarizer = new SummarizerTermFrequency();
			else if (comboBoxSummaryMethod.SelectedIndex == 1)
				summarizer = new SummarizerLuhn();

			summarizer.Parameters.Add("compressionRate", numericUpDownCompressionRate.Value.ToString());
			if (comboBoxSentenceDisplayOrder.SelectedIndex == 0)
				summarizer.Parameters.Add("displayOrder", "orderOfAppearance");
			else
				summarizer.Parameters.Add("displayOrder", "topScoring");

			SentenceCollection summarySentences = summarizer.summarize(sentences);
			this.labelSummarySentenceCount.Text = "(" + summarySentences.Count.ToString() + ")";

			// Show Summary
			foreach (Sentence sentenceEntry in summarySentences)
			{
				this.textBoxSummarySentences.Text += 
					String.Format("Sentence #{0} ({1:F2}): {2}", sentenceEntry.position, sentenceEntry.score, sentenceEntry.text) + Convert.ToChar(13) + Convert.ToChar(10) + Convert.ToChar(13) + Convert.ToChar(10);
			}

			// Show Detail
			foreach (Sentence sentenceEntry in sentences)
			{
			    this.textBoxSourceSentences.Text += 
			        "Sentence #" + sentenceEntry.position.ToString() + "-" + sentenceEntry.text + Convert.ToChar(13) + Convert.ToChar(10) + Convert.ToChar(13) + Convert.ToChar(10);

			    foreach (string token in sentenceEntry.tokens)
					this.textBoxSourceTokens.Text += 
						 token + Convert.ToChar(13) + Convert.ToChar(10);
			}

			this.tabControl1.SelectedTab = this.tabPage2;
			this.textBoxSummarySentences.SelectionLength = 0;
		}

		private void textBoxFullText_TextChanged(object sender, System.EventArgs e)
		{
			this.textBoxSourceSentences.Clear();
			this.textBoxSourceTokens.Clear();
			this.textBoxSummarySentences.Clear();
			this.labelSourceTextSentenceCount.Text = "(0)";
			this.labelSummarySentenceCount.Text = "(0)";
		}

		private void numericUpDownCompressionRate_ValueChanged(object sender, System.EventArgs e)
		{
			this.textBoxSourceSentences.Clear();
			this.textBoxSourceTokens.Clear();
			this.textBoxSummarySentences.Clear();
			this.labelSourceTextSentenceCount.Text = "(0)";
			this.labelSummarySentenceCount.Text = "(0)";
		}

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			comboBoxSummaryMethod.SelectedIndex = 0;
			comboBoxSentenceDisplayOrder.SelectedIndex = 0;
		}

		private void textBoxFullText_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				textBoxFullText.SelectAll();
			}
		}
	}
}
