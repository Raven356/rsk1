using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form2 : Form
    {
        List<List<List<string>>> Modules;
        List<List<string>> finalModules;
        List<List<string>> ModuleGroups;
        public Form2(List<List<List<string>>> modules, List<List<string>> finalModules, List<List<string>> moduleGroups)
        {
            InitializeComponent();
            Modules = modules;
            this.finalModules = finalModules;
            ModuleGroups = moduleGroups;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ModulesText.Text = "";
            finalModulesText.Text = "";
            int i = 0;
            foreach(var x in Modules)
            {
                ModulesText.Text += $"Module {i}: " + Environment.NewLine;
                foreach(var y in x)
                {
                    foreach (var z in y)
                    {
                        if(z.Length > 0)
                            ModulesText.Text += $"{z} ";
                    }
                    if(y.Count > 0)
                        ModulesText.Text += Environment.NewLine;
                }
                ModulesText.Text += Environment.NewLine;
                i++;
            }
            i = 0;
            foreach(var x in finalModules)
            {
                finalModulesText.Text += $"M{i + 1}: ";
                foreach (var y in x)
                    finalModulesText.Text += $"{y} ";
                finalModulesText.Text += Environment.NewLine;
                i++;
            }
            i = 0;
            foreach (var x in ModuleGroups)
            {
                groupedModulesText.Text += $"M{i + 1}: ";
                foreach(var y in x)
                {
                    groupedModulesText.Text += $"{y} ";
                }
                groupedModulesText.Text += Environment.NewLine;
                i++;
            }
        }
    }
}
