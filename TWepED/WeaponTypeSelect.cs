using System;
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

        private void bazookaTypeImage_Click(object sender, EventArgs e)
        {
            selectedType = WeaponType.Bazooka;
            Close();
        }

        private void grenadeTypeImage_Click(object sender, EventArgs e)
        {
            selectedType = WeaponType.Grenade;
            Close();
        }

        private void airstrikeTypeImage_Click(object sender, EventArgs e)
        {
            selectedType = WeaponType.Airstrike;
            Close();
        }
    }
}
