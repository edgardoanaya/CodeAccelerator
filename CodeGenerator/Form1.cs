using CodeGenerator.Engine;
using System;
using System.Windows.Forms;
using System.Text.Json;
using System.Reflection;
using System.Diagnostics;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        private Generator generator ;
        
        
        public Form1()
        {
            InitializeComponent();

            generator = new Generator();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            RulesGenerator rulesGenerator = new RulesGenerator("Backend_Net_7");            
            generator.Rules= rulesGenerator.GetRules();
            richTextBox1.Text = generator.Rules.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Workspace.Initialize();

            richTextBox1.Text = generator.SaveFileEntities();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = generator.Rules[generator.Rules.Count-1].Execute();
            //textBox2.Text += motor.rules[1].Replicate();
            //textBox2.Text=motor.rules[1].Replace();
            //textBox2.Text = motor.rules[1].ContentReplace;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generator.ExcuteRules();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sourceFolder = Workspace.inputsConfiguration["WorkspaceFolder"].ToString();
            string destinatioFolder = Workspace.inputsConfiguration["GenerationFolder"].ToString();
            richTextBox1.Text = generator.Copyfolder(sourceFolder,destinatioFolder);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string destinatioFolder = Workspace.inputsConfiguration["GenerationFolder"].ToString();
            richTextBox1.Text = generator.DeleteFileTemplates("*_Template.*");
        }

        private void button7_Click(object sender, EventArgs e)
        {            
            richTextBox1.Text = generator.Execute();
        }
    }
}
