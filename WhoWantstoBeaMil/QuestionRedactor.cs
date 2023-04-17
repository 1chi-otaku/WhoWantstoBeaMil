using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantstoBeaMil
{
    public partial class QuestionRedactor : Form
    {
        public Form1 par { get; set; }
        public Question[] questions { get; set; }
        public QuestionRedactor()
        {
            InitializeComponent();
        }
        public ListBox GetListBox()
        {
            return listBox1;
        }
    }
   
}
