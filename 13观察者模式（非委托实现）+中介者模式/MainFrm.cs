using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


///首先注意这个项目使用了两个设计模式，观察者模式和中介者模式

///中介者模式
///这其中的MainFrm就相当于中介者
/// 中介者模式配合观察者模式可以使观察对象和观察者彻底解耦

///观察者模式
///用非委托机制（通过接口）实现观察者模式
///首先ChildFrm1-Subject是观察对象（发布者）
///ChildFrm2-Obsever和ChildFrm3-Obsever是观察者（订阅者）
///整个项目实现的功能时MainFrm点击按钮弹出三个子窗口
///点击ChildFrm1-Subject的按钮，则ChildFrm2-Obsever和ChildFrm3-Obsever的文本框中显示当前时间

///整个项目也是实现窗体传值


///观察者模式_非委托实现
///1.新建一个接口实现事件的处理程序
///我们需要一个接口IMessageOn（这个接口的功能就是事件的处理程序），这个接口实现在文本框显示当前时间
///ChildFrm2-Obsever类和ChildFrm3-Obsever类继承于这个接口IMessageOn

///2.发布者中新建一个观察者的集合（注意这个集合是接口类型的）
///我们需要在ChildFrm1-Subject新建一个IMessageOn类型的List，这个集合中装着所有观察者
///所以我们在ChildFrm1-Subject类添加了一个 List<IMessageOn> 类型的属性MessageOnList
///在ChildFrm1-Subject类的构造函数中给属性MessageOnList，直接new一个对象,作初始化

///3.发布者发布消息
///当点击ChildFrm1-Subject中的按钮时，遍历观察者集合MessageOnList，
///调用每一个观察者的事件处理程序（就是那个接口IMessageOn）

///通过接口实现观察者模式的优点：
///当你想要删除一个观察者，你只要不把这个对象不加入的观察者集合中
///但你想要增加一个观察者，你只要把这个对象放在观察者集合中




namespace _13观察者模式_非委托实现__中介者模式
{
    /// <summary>
    /// 主窗体，这里就是中介者模式中的中介
    /// 为嘛要用这么个所谓的中介模式呢？
    /// 通过主窗体这个中介，你去看子窗体1一点都没有子窗体2和子窗体3的代码
    /// 你要是删除一个子窗体2，你只需要修改主窗体就可以了
    /// 这就是中介者模式的精髓
    /// </summary>
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChildFrm1_Subject subjectFrm = new ChildFrm1_Subject();
            subjectFrm.Show();


            ChildFrm2_Observer observerFrm1 = new ChildFrm2_Observer();
            subjectFrm.MessageOnList.Add(observerFrm1);//把观察者放到观察者的集合中
            observerFrm1.Show();

            ChildFrm3_Observer observerFrm2 = new ChildFrm3_Observer();
            subjectFrm.MessageOnList.Add(observerFrm2);//把观察者放到观察者的集合中
            observerFrm2.Show();
        }
    }
}
