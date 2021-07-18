using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _20_UsingControls
{
    public partial class Form1 : Form
    {
        Random random = new Random(37);
        public Form1()
        {
            InitializeComponent();

            lvDummy.View = View.Details;
            lvDummy.Columns.Add("Name");
            lvDummy.Columns.Add("Depth");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families;
            foreach (FontFamily font in Fonts)
                cboFont.Items.Add(font.Name);
        }

        void ChangeFont()
        {
            if (cboFont.SelectedIndex < 0)          //cboFont에서 선택한 항목이 없으면 메소드 종료
                return;

            FontStyle style = FontStyle.Regular;    //FontStyle 객체 초기화

            if (chkBold.Checked)
                style |= FontStyle.Bold;

            if (chkItalic.Checked)
                style |= FontStyle.Italic;

            txtSampleText.Font = new Font((string)cboFont.SelectedItem, 10, style);
        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void tbDummy_Scroll(object sender, EventArgs e)
        {
            pgDummy.Value = tbDummy.Value;
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Modal Form";
            frm.Width = 300;
            frm.Height = 100;
            frm.BackColor = Color.Red;
            frm.ShowDialog(); //Modal창 띄우기
        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Modaless Form";
            frm.Width = 300;
            frm.Height = 300;
            frm.BackColor = Color.Green;
            frm.Show(); //Modaless창 띄우기
        }

        private void btnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtSampleText.Text, "MessageBox Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //TreeView의 각 노드를 ListView로 옮겨 표시하는 기능
        void TreeToList()
        {
            lvDummy.Items.Clear();
            foreach (TreeNode node in tvDummy.Nodes)
                TreeToList(node);
        }
        void TreeToList(TreeNode Node)
        {
            lvDummy.Items.Add(
                new ListViewItem(
                    new string[] { Node.Text, 
                        Node.FullPath.Count(f => f == '\\').ToString()}));

            foreach(TreeNode node in Node.Nodes)
            {
                TreeToList(node);
            }
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            tvDummy.Nodes.Add(random.Next().ToString());
            TreeToList();
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            if(tvDummy.SelectedNode == null)
            {
                MessageBox.Show("선택된 노드가 없습니다.", "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tvDummy.SelectedNode.Nodes.Add(random.Next().ToString());
            tvDummy.SelectedNode.Expand();
            TreeToList();
        }
    }
}
