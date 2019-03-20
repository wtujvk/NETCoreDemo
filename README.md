# CAP.Demo
1. CAP.Web
CAP原则又称CAP定理，指的是在一个分布式系统中，Consistency（一致性）、 Availability（可用性）、Partition tolerance（分区容错性），三者不可兼得。
这里只是以SqlServer+RabbitMQ 为例，环境是 Win10+VS2017+.NetCore2.0
*******************************************
其他要求：
需要连接 RabbitMQ 和SqlServer ， 在 appsettings.Development.json和中修改配置。
2. ELK1.Web
es写日志
3. ELK2.Web
elk写日志
Throttle限流框架使用
4. asp.net限流框架的使用 MvcThrottleDemo
5. webapi限流框架的使用 WebApiThrottleDemo
参考：
https://github.com/dotnetcore/CAP
https://www.cnblogs.com/CoderAyu/p/9527012.html

加入部分测试以及 efcore的内容
