using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWepED.Properties;

namespace TWepED
{
    public partial class WeaponItem : UserControl
    {
        public Weapon curWeapon;
        public int ID;
        public WeaponItem(Weapon wep, int id)
        {
            InitializeComponent();

            weaponNameLabel.Text = wep.Name;
            ID = id;

            curWeapon = wep;

            if (curWeapon.Type == WeaponType.Bazooka)
            {
                weaponTypePicture.Image = Resources.bazooka;
            }
            else if (curWeapon.Type == WeaponType.Grenade)
            {
                weaponTypePicture.Image = Resources.grenade;
            }
            else if (curWeapon.Type == WeaponType.Airstrike)
            {
                weaponTypePicture.Image = Resources.airstrike;
            }
            else
            {
                weaponTypePicture.Image = Resources.unknown;
            }
        }

        private void WeaponItem_Load(object sender, EventArgs e)
        {

        }
    }
}
