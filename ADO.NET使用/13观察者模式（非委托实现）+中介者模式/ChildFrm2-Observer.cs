using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _13观察者模式_非委托实现__中介者模式
{
    public partial class ChildFrm2_Observer : Form,IMessageOn
    {
        public ChildFrm2_Observer()
        {
            InitializeComponent();
        }

        public void MessageOn(string str)
        {
            this.txtMessage.Text=str+"  "+DateTime.Now.ToString();
        }
    }
}
