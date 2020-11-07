using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWepED
{
    public partial class WeaponTypeSelect : Form
    {
        public WeaponType selectedType = WeaponType.Unknown;
        public WeaponTypeSelect()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selectedType = WeaponType.Bazooka;
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            selectedType = WeaponType.Grenade;
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            selectedType = WeaponType.Airstrike;
            Close();
        }

        private void WeaponTypeSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
