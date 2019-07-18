# Complete-HCIPro
2019年大二下学期HCI课程项目设计


本项目采用第一代kinect       sdk采用v1.8版本
实现了对三个基本动作 深蹲,仰卧起坐,平板支撑的简单识别,前两个计数,最后一个计时
如果有什么源没有添加请在 找dll网站进行下载

Microsoft.Samples.Kinect.WpfViewers项目中包含了三种不同类型动作的骨骼定义,该项目下的三个连续的同前缀名的xaml中包含了对不同动作的识别标准(ps:分数每次
加6/5是因为前端控件中进度条的长度为120,而满分为100),前端采用了C# wpf的框架书写,分数的传递采用了数据绑定(涉及到了两层页面,大家可以深入研究.......)
真正的页面书写在KinectExplorer项目下,该项目下的带有Window的xaml是最终的页面,Microsoft.Samples.Kinect.WpfViewers中的xaml只包含了图像,没有除图像外的其他控件........
