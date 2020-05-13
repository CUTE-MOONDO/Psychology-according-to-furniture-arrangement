using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moondo
{
    public partial class StartForm : Form
    {
        public static String userName;
        public StartForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        { 
            userName = nameBox.Text;

            if (userName.Length < 2)
            {
                MessageBox.Show("이름을 2글자 이상으로 설정해주세요 ! ", "이름이 너무 짧아요 ! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                TestForm testStart = new TestForm();

                testStart.Show();
                this.Hide();
            }
        }

        private void Textbox_KeyDown(object sender, KeyEventArgs e) //텍스트박스에서 EnterKey 눌렀을 때 Button1_Click()실행
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Button1_Click(sender, e);
            }
        }
    }
}
