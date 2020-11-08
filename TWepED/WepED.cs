using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TWepED
{
    public partial class WepED : Form
    {
        public Weapon curWeapon;
        public WepED(Weapon weapon)
        {
            InitializeComponent();

            curWeapon = weapon;
        }

        private void WepED_Load(object sender, EventArgs e)
        {
            foreach (XmlNode item in curWeapon.weaponNode.ChildNodes)
            {
                Property prop = new Property();

                if (item.Name == "Name")
                {
                    prop.textBox1.Text = curWeapon.Name;
                }
                else
                {
                    prop.textBox1.Text = item.InnerText;
                }
                prop.label1.Text = item.Name;

                weaponPropsPanel.Controls.Add(prop);
            }

            Text = "TWepED - " + curWeapon.Name;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < weaponPropsPanel.Controls.Count; i++)
            {
                Property prop = (Property)weaponPropsPanel.Controls[i];

                if (prop.label1.Text == "Name")
                {
                    curWeapon.nameNode.FirstChild.InnerText = prop.textBox1.Text;
                    continue;
                }

                curWeapon.weaponNode.ChildNodes[i].InnerText = prop.textBox1.Text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
