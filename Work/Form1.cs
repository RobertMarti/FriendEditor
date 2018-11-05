using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FriendsEntities dataContext = new FriendsEntities();

            foreach (var friend in dataContext.tabFriends)
            {
                MessageBox.Show(friend.Name);
            }
        }
    }
}
