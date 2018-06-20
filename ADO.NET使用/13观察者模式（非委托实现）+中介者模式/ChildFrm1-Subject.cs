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
    public partial class ChildFrm1_Subject : Form
    {
        public ChildFrm1_Subject()
        {
            InitializeComponent();
            MessageOnList = new List<IMessageOn>();//直接在构造函数中初始化观察者集合
        }

        //为 ChildFrm1_Subject类（发布者）一个装观察者的集合属性
        //注意我们的这个集合是接口IMessageOn类型的，
        //但是在MainFrm中我们是把整个观察者对象（窗口）添加到这个集合
        //为什么可以呢？你别忘了我们的观察者都是继承了这个接口IMessageOn，这里就相当于子类对象赋值给了父类对象，有何不可！
        public List<IMessageOn> MessageOnList { get; set; }

        /// <summary>
        /// 点击ChilFrm1-Subject窗体的按钮，触发事件，订阅者实现事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessage_Click(object sender, EventArgs e)
        {
            foreach (IMessageOn  item in MessageOnList )
            {
                item.MessageOn("随便给参数吧");
            }
        }

        

    }
}
